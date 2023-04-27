using CN_Project;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CN_Project_Client
{
    public partial class ClientWindow : Form
    {
        #region Variable Definitions
        // A boolean indicating whether it's currently the local player's turn.
        private bool isMyTurn = false;

        // The game board, represented as a 3x3 array of characters ('X', 'O', or ' ').
        private static char[,] grid = new char[3, 3];

        // A dictionary mapping each button on the game board to a boolean indicating whether it's currently locked (i.e., can't be clicked).
        private static Dictionary<Control, bool> isButtonLocked = new Dictionary<Control, bool>();

        // A 2D array of Control objects representing each button on the game board.
        private static Control[,] ButtonGrid = new Control[3, 3];

        // A list of strings representing the scores of each round of the game.
        private static List<string> scores = new List<string>();

        // The text of the currently selected cell (i.e., the cell the local player has clicked on).
        private static string cellSelected = "  ";

        // The symbol used by the local player (either 'X' or 'O').
        private static char mySymbol;

        // The symbol used by the opponent player (the opposite of mySymbol).
        private static char opponentSymbol;

        // The total number of rounds in the game.
        private static int numRounds;

        // The current round number (1-indexed).
        private static int currentRound = 1;

        // The number of rounds won by the local player.
        private static int myWins = 0;

        // The number of rounds lost by the local player.
        private static int myLosses = 0;

        // The socket used for the server's connection.
        private static Socket serverSocket;

        // A delegate for updating the color and text of a label in the GUI.
        public delegate void labelDelegate(Color labelColor, string labelText);

        // A delegate for updating the text of a cell (i.e., a button) in the GUI.
        public delegate void cellDelegate(RadioButton button, string text);

        // A delegate for enabling or disabling the controls
        public delegate void controlsDelegate(bool status);

        #endregion
        
        public ClientWindow()
        {
            InitializeComponent();

            foreach (Control table in Controls.OfType<TableLayoutPanel>())
            {
                foreach (RadioButton button in table.Controls)
                {
                    isButtonLocked.Add(button, false);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string buttonName = "Button" + i.ToString() + "_" + j.ToString();
                    Control[] button = Controls.Find(buttonName, true);
                    ButtonGrid[i, j] = button[0];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        #region Labels and IP Box
        //Runs at every keypress in the port text box, used to only allow digits 
        private void IPTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        //Sets cursor to the IP window as soon as the window opens
        private void ClientWindow_Shown(object sender, EventArgs e)
        {
            IPTextBox.Focus();
        }

        //Function that changes the color of the ConnectionStatus label (can be called as a delegate too
        public void ChangeStatus(Color labelColor, string labelText)
        {
            ConnectionStatusLabel.BackColor = labelColor;
            ConnectionStatusLabel.Text = labelText;
        }

        public void ChangeTurn(Color labelColor, string labelText)
        {
            TurnLabel.Text = labelText;
            TurnLabel.ForeColor = labelColor;
        }

        private void ChangeRound(Color labelColor, string labelText)
        {
            RoundLabel.Text = labelText;
        }

        #endregion

        #region Networking
        //Background thread function that listens for messages and receives them
        public void ReceiveMessages()
        {
            while (true)
            {
                try
                {
                    //Receive the message in a buffer and resize the buffer to fit the message
                    byte[] recvBuffer = new byte[serverSocket.SendBufferSize];
                    int bytesReceived = serverSocket.Receive(recvBuffer);
                    Array.Resize(ref recvBuffer, bytesReceived);

                    string recvMessage = Encoding.ASCII.GetString(recvBuffer);
                    int x, y;
                    x = recvMessage.ElementAt(0) - '0';
                    y = recvMessage.ElementAt(1) - '0';
                    mySymbol = recvMessage.ElementAt(2);

                    //Assign opponent symbol according to received player symbol
                    if (mySymbol == 'O')
                        opponentSymbol = 'X';
                    else 
                        opponentSymbol = 'O';

                    //Parse number of rounds from received message
                    numRounds = recvMessage.ElementAt(3) - '0';

                    SelectCell(x, y, opponentSymbol);
                    isMyTurn = true;
                    cellSelected = "  ";

                    TurnLabel.BeginInvoke(new labelDelegate(ChangeTurn), Color.DeepSkyBlue, "Turn: Yours");

                    if (CheckDraw())
                    {
                        scores.Add("Round " + currentRound + ": Draw!");
                        MatchWonWindow matchWindow = new MatchWonWindow("It's a draw!", scores, Color.White);
                        matchWindow.ShowDialog();
                        ResetGame(false);
                        continue;
                    }

                    if (CheckWinner(opponentSymbol))
                    {
                        // If this move lost you the tournament, display the tournament won message and reset
                        if (CheckMatchOutcome(false))
                        {
                            scores.Add(opponentSymbol + " won the match!");
                            MatchWonWindow matchWindow = new MatchWonWindow("Oops! You lost the tournament!", scores, Color.Crimson);
                            matchWindow.ShowDialog();
                            ResetGame(true);
                            continue;
                        }

                        //Otherwise display the round won message
                        RoundWonWindow window = new RoundWonWindow("You lost the round!", "Dang it!", Color.Crimson);
                        window.ShowDialog();

                        ResetGame(false);
                        currentRound++;
                        RoundLabel.BeginInvoke(new labelDelegate(ChangeRound), Color.White, "Round: " + currentRound.ToString());
                        continue;
                    }
                }
                catch
                {
                    //If any disconnection occurs, set the status to disconnected and close the socket
                    ResetGame(true);
                    ConnectionStatusLabel.BeginInvoke(new labelDelegate(ChangeStatus), Color.Red, "Disconnected");
                    this.BeginInvoke(new controlsDelegate(EnableOrDisableControls), false);
                    serverSocket.Close();
                    break;
                }
            }
            
        }

        //Runs when the connect button is clicked
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            int port;
            string[] address = IPTextBox.Text.Split(':');
            string ip = address[0];
            int.TryParse(address[1], out port);

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            try
            {
                //Try to connect to the host and set the status to connected if it succeeds
                serverSocket.Connect(localEndPoint);
                ChangeStatus(Color.DarkGreen, "Connected");
                EnableOrDisableControls(true);

                //Creates a new thread to accept an incoming connection, since it is a blocking call we do it in a separate thread
                Thread thread = new Thread(ReceiveMessages);
                thread.IsBackground = true; //Ensures that the thread doesn't keep the program running
                thread.Start();
            }
            catch
            {
                MessageBox.Show("Unable to connect to host! Make sure the host is listening for a connection, and make sure you entered the correct IP and Port.");
                return;
            }
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            ResetGame(true);
            if (serverSocket == null) return;
            EnableOrDisableControls(false);
            serverSocket.Shutdown(SocketShutdown.Both);
            serverSocket.Close();
            ChangeStatus(Color.Red, "Disconnected");

        }

        //Function that runs when the send button is clicked - Sends the items of the textbox to the server
        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (!isMyTurn)
            {
                MessageBox.Show("It is the opponent's turn!");
                return;
            }

            if (cellSelected == "  ")
            {
                MessageBox.Show("You haven't selected any cell!");
                return;
            }

            if (serverSocket == null) return;

            byte[] sendData = Encoding.ASCII.GetBytes(cellSelected);
            serverSocket.Send(sendData);
            cellSelected = "  ";
            isMyTurn = false;
            ChangeTurn(Color.Crimson, "Turn: Opponent's");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    RadioButton button = (RadioButton)ButtonGrid[i, j];
                    if (button.Checked && !isButtonLocked[button])
                    {
                        isButtonLocked[button] = true;
                        grid[i, j] = mySymbol;
                        button.ForeColor = Color.DeepSkyBlue;
                    }
                }
            }

            if (CheckDraw())
            {
                scores.Add("Round " + currentRound + ": Draw!");
                MatchWonWindow matchWindow = new MatchWonWindow("It's a draw!", scores, Color.White);
                matchWindow.ShowDialog();
                ResetGame(false);
                return;
            }

            if (CheckWinner(mySymbol))
            {
                if (CheckMatchOutcome(true))
                {
                    scores.Add(mySymbol + " won the match!");
                    MatchWonWindow matchWindow = new MatchWonWindow("Congratulations! You won the tournament!", scores, Color.DeepSkyBlue);
                    matchWindow.ShowDialog();
                    ResetGame(true);
                    return;
                }

                RoundWonWindow window = new RoundWonWindow("You won the round!", "Nice!", Color.DeepSkyBlue);
                window.ShowDialog();

                ResetGame(false);
                currentRound++;
                ChangeRound(Color.White, "Round: " + currentRound.ToString());
            }
        }
        #endregion

        #region Game Logic
        private bool CheckMatchOutcome(bool checkingWinner)
        {
            if (checkingWinner)
                return myWins == Math.Ceiling(numRounds / 2.0);
            else
                return myLosses == Math.Ceiling(numRounds / 2.0);
        }

        private void ResetGame(bool resetTournament)
        {
            isMyTurn = false;
            cellSelected = "  ";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = ' ';
                    isButtonLocked[ButtonGrid[i, j]] = false;
                    ButtonGrid[i, j].Tag = "false";
                    ButtonGrid[i, j].ForeColor = Color.White;
                    ButtonGrid[i, j].BeginInvoke(new cellDelegate(ClearButtonText), ButtonGrid[i, j], "");
                }
            }

            if (TurnLabel.InvokeRequired)
                TurnLabel.BeginInvoke(new labelDelegate(ChangeTurn), Color.Crimson, "Turn: Opponent's");
            else
                ChangeTurn(Color.Crimson, "Turn: Opponent's");

            if (resetTournament)
            {
                myWins = 0;
                myLosses = 0;
                currentRound = 1;
                RoundLabel.BeginInvoke(new labelDelegate(ChangeRound), Color.White, "Round: " + currentRound.ToString());
            }

        }

        // Enables or disables game controls
        // status: Whether to enable or disable controls
        private void EnableOrDisableControls(bool status)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)               
                    ButtonGrid[i, j].Enabled = status;

            //Enable or disable other controls
            SendBtn.Enabled = status;
            ScoreboardBtn.Enabled = status;
            RoundLabel.Visible = status;
            TurnLabel.Visible = status;

            //Enable or disable network controls
            ConnectBtn.Enabled = !status;
            IPTextBox.Enabled = !status;
        }

        private void MarkCell(Control button, string cellText)
        {
            button.Text = cellText;

            if (cellText == opponentSymbol.ToString())
                button.ForeColor = Color.Crimson;
            else
                button.ForeColor = Color.DeepSkyBlue;
        }

        private void SelectCell(int x, int y, char player)
        {

            Control buttonToChange = ButtonGrid[x, y];

            // If the current cell is already locked, then do nothing
            if (isButtonLocked[buttonToChange])
                return;

            //If the selection was done by the other player, lock the cell
            if (player == opponentSymbol)
            {
                isButtonLocked[buttonToChange] = true;
                grid[x, y] = player;
            }

            // Set the Tag of the previously selected cell to false, because we are about to set the newly selected one to true
            if (cellSelected != "  ")
            {
                int oldX = cellSelected.ElementAt(0) - '0';
                int oldY = cellSelected.ElementAt(1) - '0';
                Control previousButton = ButtonGrid[oldX, oldY];
                previousButton.Tag = "false";
            }

            buttonToChange.Tag = "true";

            if (buttonToChange.InvokeRequired)
                buttonToChange.BeginInvoke(new cellDelegate(MarkCell), buttonToChange, player.ToString());
            else
                MarkCell(buttonToChange, player.ToString());

            cellSelected = x.ToString() + y.ToString();
        }

        private void ResetUncheckedButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    RadioButton button = (RadioButton) ButtonGrid[i, j];
                    if (button.Checked || isButtonLocked[ButtonGrid[i, j]] == true)
                        continue;

                    button.ForeColor = Color.White;
                    button.Text = "";
                }
            }
        }

        private void ClearButtonText(RadioButton button, string text)
        {
            button.Text = text;
        }

        private bool CheckDraw()
        {
            //If there is no empty space in the grid, its a draw!
            return !isButtonLocked.ContainsValue(false);
        }

        private bool CheckWinner(char player)
        {
            //Horizontal checks
            for (int i = 0; i < 3 ; i++)
            {
                //Check who won and update the scoreboard and win/loss counter accordingly
                if (grid[i, 0] == player && grid[i, 1] == player && grid[i, 2] == player)
                {
                    if (player == mySymbol)
                    {
                        scores.Add("Round" + currentRound.ToString() + ": " + mySymbol + " won!");
                        myWins++;
                    }
                    else
                    {
                        scores.Add("Round" + currentRound.ToString() + ": " + opponentSymbol + " won!");
                        myLosses++;
                    }
                    return true;
                }
            }
            
            //Vertical checks
            for (int i = 0; i<3; i++)
            {
                if (grid[0, i] == player && grid[1, i] == player && grid[2, i] == player)
                {
                    //Check who won and update the scoreboard and win/loss counter accordingly
                    if (player == mySymbol)
                    {
                        scores.Add("Round" + currentRound.ToString() + ": " + mySymbol + " won!");
                        myWins++;
                    }
                    else
                    {
                        scores.Add("Round" + currentRound.ToString() + ": " + opponentSymbol + " won!");
                        myLosses++;
                    }
                    return true;
                }
            }

            //Forward diagonal check
            if (grid[0,0] == player && grid[1,1] == player && grid[2,2] == player)
            {
                //Check who won and update the scoreboard and win/loss counter accordingly
                if (player == mySymbol)
                {
                    scores.Add("Round" + currentRound.ToString() + ": " + mySymbol + " won!");
                    myWins++;
                }
                else
                {
                    scores.Add("Round" + currentRound.ToString() + ": " + opponentSymbol + " won!");
                    myLosses++;
                }
                return true;
            }

            //Backward diagonal check
            if (grid[0, 2] == player && grid[1, 1] == player && grid[2, 0] == player)
            {
                //Check who won and update the scoreboard and win/loss counter accordingly
                if (player == mySymbol)
                {
                    scores.Add("Round" + currentRound.ToString() + ": " + mySymbol + " won!");
                    myWins++;
                }
                else
                {
                    scores.Add("Round" + currentRound.ToString() + ": " + opponentSymbol + " won!");
                    myLosses++;
                }
                return true;
            }

            return false;
        }

        #endregion

        #region Button Click Handlers

        private void ScoreboardBtn_Click(object sender, EventArgs e)
        {
            ScoreboardWindow scoreWindow = new ScoreboardWindow(scores);
            scoreWindow.ShowDialog();
        }

        private void Button0_0_Click(object sender, EventArgs e)
        {
            if (isMyTurn == false)
                return;
            SelectCell(0, 0, mySymbol);
            ResetUncheckedButtons();

        }

        private void Button0_1_Click(object sender, EventArgs e)
        {
            if (isMyTurn == false)
                return;
            SelectCell(0, 1, mySymbol);
            ResetUncheckedButtons();

        }

        private void Button0_2_Click(object sender, EventArgs e)
        {
            if (isMyTurn == false)
                return;
            SelectCell(0, 2, mySymbol);
            ResetUncheckedButtons();

        }

        private void Button1_0_Click(object sender, EventArgs e)
        {
            if (isMyTurn == false)
                return;
            SelectCell(1, 0, mySymbol);
            ResetUncheckedButtons();

        }

        private void Button1_1_Click(object sender, EventArgs e)
        {
            if (isMyTurn == false)
                return;
            SelectCell(1, 1, mySymbol);
            ResetUncheckedButtons();

        }

        private void Button1_2_Click(object sender, EventArgs e)
        {
            if (isMyTurn == false)
                return;
            SelectCell(1, 2, mySymbol);
            ResetUncheckedButtons();

        }

        private void Button2_0_Click(object sender, EventArgs e)
        {
            if (isMyTurn == false)
                return;
            SelectCell(2, 0, mySymbol);
            ResetUncheckedButtons();

        }

        private void Button2_1_Click(object sender, EventArgs e)
        {
            if (isMyTurn == false)
                return;
            SelectCell(2, 1, mySymbol);
            ResetUncheckedButtons();

        }

        private void Button2_2_Click(object sender, EventArgs e)
        {
            if (isMyTurn == false)
                return;
            SelectCell(2, 2, mySymbol);
            ResetUncheckedButtons();

        }
        #endregion

        #region Button Hover Handlers
        private void HoverButton(int x, int y, Color borderColor, int borderSize, char buttonText)
        {
            if (!isMyTurn)
                return;

            RadioButton buttonToChange = (RadioButton)ButtonGrid[x, y];

            if ((string)buttonToChange.Tag == "false")
                buttonToChange.Text = buttonText.ToString();

            buttonToChange.FlatAppearance.BorderColor = borderColor;
            buttonToChange.FlatAppearance.BorderSize = borderSize;

        }

        private void Button0_0_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(0, 0, Color.Aqua, 3, mySymbol);
        }

        private void Button0_0_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(0, 0, Color.White, 1, ' ');
        }

        private void Button0_1_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(0, 1, Color.Aqua, 3, mySymbol);
        }

        private void Button0_1_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(0, 1, Color.White, 1, ' ');
        }

        private void Button0_2_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(0, 2, Color.Aqua, 3, mySymbol);
        }

        private void Button0_2_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(0, 2, Color.White, 1, ' ');
        }

        private void Button1_0_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(1, 0, Color.Aqua, 3, mySymbol);
        }

        private void Button1_0_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(1, 0, Color.White, 1, ' ');
        }

        private void Button1_1_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(1, 1, Color.Aqua, 3, mySymbol);
        }

        private void Button1_1_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(1, 1, Color.White, 1, ' ');
        }

        private void Button1_2_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(1, 2, Color.Aqua, 3, mySymbol);
        }

        private void Button1_2_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(1, 2, Color.White, 1, ' ');
        }

        private void Button2_0_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(2, 0, Color.Aqua, 3, mySymbol);
        }

        private void Button2_0_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(2, 0, Color.White, 1, ' ');
        }

        private void Button2_1_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(2, 1, Color.Aqua, 3, mySymbol);
        }

        private void Button2_1_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(2, 1, Color.White, 1, ' ');
        }

        private void Button2_2_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(2, 2, Color.Aqua, 3, mySymbol);
        }

        private void Button2_2_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(2, 2, Color.White, 1, ' ');
        }

#endregion

    }
}
