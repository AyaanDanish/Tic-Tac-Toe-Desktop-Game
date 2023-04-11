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

namespace CN_Project_Server
{
    public partial class ServerWindow : Form
    {
        #region Variable Definitions
        // A boolean indicating whether it's currently the local player's turn.
        private bool isMyTurn = true;

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

        // The socket used for listening for incoming connections.
        private static Socket listenerSocket;

        // The socket used for the client's connection.
        private static Socket clientSocket;

        // A delegate for updating the color and text of a label in the GUI.
        public delegate void labelDelegate(Color labelColor, string labelText);

        // A delegate for updating the text of a cell (i.e., a button) in the GUI.
        public delegate void cellDelegate(RadioButton button, string text);

        // A delegate for enabling or disabling the controls
        public delegate void controlsDelegate(bool status);

        #endregion

        public ServerWindow()
        {
            InitializeComponent();

            // Loop through all TableLayoutPanels and radio buttons to set their initial lock state to false
            foreach (Control table in Controls.OfType<TableLayoutPanel>())
            {
                foreach (RadioButton button in table.Controls)
                {
                    isButtonLocked.Add(button, false);
                }
            }

            // Find and store all the radio buttons in a 2D array
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string buttonName = "Button" + i.ToString() + "_" + j.ToString();
                    Control[] button = Controls.Find(buttonName, true);
                    ButtonGrid[i, j] = button[0];
                }
            }
        }

        #region Labels and Port Box

        // This method runs when the user types in the PortTextBox and only allows digits to be entered
        private void PortTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // This method runs when the ServerWindow is shown
        // It opens a StartupWindow dialog box to get the number of rounds and player symbol
        // It also sets the opponent's symbol and focuses on the PortTextBox
        private void ServerWindow_Shown(object sender, EventArgs e)
        {
            string setupSymbol = "";
            using (StartupWindow startup = new StartupWindow())
            {
                var result = startup.ShowDialog();
                if (result == DialogResult.OK)
                {
                    numRounds = startup.numRounds;
                    setupSymbol = startup.playerSymbol;
                }
            }

            //If setup was left incomplete, then exit the application
            if (setupSymbol == "")
                Application.Exit();

            else //Assign the global player to the symbol received from setup screen
                mySymbol = setupSymbol.ElementAt(0);

            if (mySymbol == 'X')
                opponentSymbol = 'O';
            else
                opponentSymbol = 'X';

            PortTextBox.Focus();
        }

        // This method changes the color of the ConnectionStatus label and enables/disables controls based on the given bool
        public void ChangeStatus(Color labelColor, string labelText)
        {
            if (labelColor == Color.DarkGreen)
                EnableOrDisableControls(true);

            ConnectionStatusLabel.BackColor = labelColor;
            ConnectionStatusLabel.Text = labelText;
        }

        // This method changes the text and color of the TurnLabel
        public void ChangeTurn(Color labelColor, string labelText)
        {
            TurnLabel.Text = labelText;
            TurnLabel.ForeColor = labelColor;
        }

        // This method changes the text of the RoundLabel
        private void ChangeRound(Color labelColor, string labelText)
        {
            RoundLabel.Text = labelText;
        }

        #endregion

        #region Networking

        //Background thread function that listens for messages and receives them
        public void ReceiveMessages()
        {
            //Accept an incoming connection
            clientSocket = listenerSocket.Accept();

            //Set status to connected using delegate
            ConnectionStatusLabel.BeginInvoke(new labelDelegate(ChangeStatus), Color.DarkGreen, "Connected");

            //Listener socket is no longer needed so we can close it now
            listenerSocket.Close();

            while (true)
            {
                try
                {
                    //Receive the message in a buffer and resize the buffer to fit the message
                    byte[] recvBuffer = new byte[clientSocket.SendBufferSize];
                    int bytesReceived = clientSocket.Receive(recvBuffer);
                    Array.Resize(ref recvBuffer, bytesReceived);

                    //Parse the message to get the position received, and set my turn to true
                    string recvMessage = Encoding.ASCII.GetString(recvBuffer);
                    int x, y;
                    x = recvMessage.ElementAt(0) - '0';
                    y = recvMessage.ElementAt(1) - '0';
                    SelectCell(x, y, opponentSymbol);
                    isMyTurn = true;
                    cellSelected = "  ";

                    //Call change turn status
                    TurnLabel.BeginInvoke(new labelDelegate(ChangeTurn), Color.Crimson, "Turn: Yours");

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
                        // If this move lost you the tournament, then print and reset
                        if (CheckMatchOutcome(false))
                        {
                            scores.Add(opponentSymbol + " won the match!");
                            MatchWonWindow matchWindow = new MatchWonWindow("Oops! You lost the tournament!", scores, Color.DeepSkyBlue);
                            matchWindow.ShowDialog();
                            ResetGame(true);
                            continue;
                        }

                        //Otherwise display the round won message
                        RoundWonWindow roundWindow = new RoundWonWindow("You lost the round!", "Dang it!", Color.DeepSkyBlue);
                        roundWindow.ShowDialog();

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
                    clientSocket.Close();
                    break;
                }
            }
        }

        //Runs when the listen button is clicked
        private void ListenBtn_Click(object sender, EventArgs e)
        {
            //Extracts the port number from the text box and stores it in 'port'
            int port;
            Int32.TryParse(PortTextBox.Text, out port);


            //Create new server socket to listen for incoming connections
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Binds this socket to the port that was entered, and listens for connections (blocking call)
            try
            {
                listenerSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                listenerSocket.Listen(0);
            }
            catch
            {
                MessageBox.Show("This port is already in use, please enter another.");
                return;
            }

            //Set status to awaiting connection
            ChangeStatus(Color.Yellow, "Awaiting Connection");

            //Creates a new thread to accept an incoming connection 
            Thread thread = new Thread(ReceiveMessages);
            thread.IsBackground = true; //Ensures that the thread doesn't keep the program running
            thread.Start();

        }

        //Function that runs when the send button is clicked - Sends the items of the textbox to the client
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

            if (clientSocket == null) return;

            byte[] sendData = Encoding.ASCII.GetBytes(cellSelected + opponentSymbol + numRounds.ToString());
            clientSocket.Send(sendData);
            cellSelected = "  ";
            isMyTurn = false;
            ChangeTurn(Color.DeepSkyBlue, "Turn: Opponent's");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    RadioButton button = (RadioButton)ButtonGrid[i, j];

                    if (button.Checked && !isButtonLocked[button])
                    {
                        isButtonLocked[button] = true;
                        button.ForeColor = Color.Crimson;
                        grid[i, j] = mySymbol;
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
                    MatchWonWindow matchWindow = new MatchWonWindow("Congratulations! You won the tournament!", scores, Color.Crimson);
                    matchWindow.ShowDialog();
                    ResetGame(true);
                    return;
                }

                RoundWonWindow window = new RoundWonWindow("You won the round!", "Nice!", Color.Crimson);
                window.ShowDialog();

                ResetGame(false);
                currentRound++;

                ChangeRound(Color.White, "Round: " + currentRound.ToString());
            }
        }


        //Runs when disconnect button is clicked, disconnects the connection
        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            ResetGame(true);
            if (clientSocket == null) return;
            EnableOrDisableControls(false);
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            ChangeStatus(Color.Red, "Disconnected");
        }

        #endregion

        #region Game Logic

        // Check if the current round outcome matches the result of the tournament
        // Returns true if the current player has won the tournament, false otherwise
        private bool CheckMatchOutcome(bool checkingWinner)
        {
            if (checkingWinner)
                return myWins == Math.Ceiling(numRounds / 2.0);
            else
                return myLosses == Math.Ceiling(numRounds / 2.0);
        }

        // Resets the game to its initial state
        // resetTournament: Whether to reset the tournament or not
        private void ResetGame(bool resetTournamentToo)
        {
            isMyTurn = true;
            cellSelected = "  ";

            // Clear the game grid and buttons
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

            // Update turn status and round label
            if (TurnLabel.InvokeRequired)
                TurnLabel.BeginInvoke(new labelDelegate(ChangeTurn), Color.Crimson, "Turn: Yours");
            else
                ChangeTurn(Color.Crimson, "Turn: Yours");

            if (resetTournamentToo)
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
            // Enable or disable each button on the grid
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    ButtonGrid[i, j].Enabled = status;

            // Enable or disable other game controls
            SendBtn.Enabled = status;
            ScoreboardBtn.Enabled = status;
            RoundLabel.Visible = status;
            TurnLabel.Visible = status;

            //Enable or disable network controls
            ListenBtn.Enabled = !status;
            PortTextBox.Enabled = !status;
        }

        // Sets the text and color of a button in the game grid
        // button: The button to modify
        // cellText: The text to set on the button
        private void MarkCell(Control button, string cellText)
        {
            button.Text = cellText;

            // Change the text color based on which player selected the cell
            if (cellText == mySymbol.ToString())
                button.ForeColor = Color.Crimson;
            else
                button.ForeColor = Color.DeepSkyBlue;
        }

        private void SelectCell(int x, int y, char player)
        {
            // Get the button control at the specified x and y coordinates
            Control buttonToChange = ButtonGrid[x, y];

            // If the current cell is already locked, then do nothing
            if (isButtonLocked[buttonToChange])
                return;

            // If the selection was done by the other player, lock the cell
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

            // Set the Tag property of the current button to "true"
            buttonToChange.Tag = "true";

            // If we need to invoke the delegate, then use BeginInvoke to execute it asynchronously on the UI thread
            if (buttonToChange.InvokeRequired)
                buttonToChange.BeginInvoke(new cellDelegate(MarkCell), buttonToChange, player.ToString());
            else
                MarkCell(buttonToChange, player.ToString());

            // Save the selected cell's coordinates as a string
            cellSelected = x.ToString() + y.ToString();
        }

        // Reset the text and foreground color of any unchecked and unlocked buttons
        private void ResetUncheckedButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Get the RadioButton control at the current coordinates
                    RadioButton button = (RadioButton)ButtonGrid[i, j];

                    // If the button is checked or locked, then skip it
                    if (button.Checked || isButtonLocked[ButtonGrid[i, j]] == true)
                        continue;

                    // Reset the button's text and foreground color
                    button.ForeColor = Color.White;
                    button.Text = "";
                }
            }
        }

        // Clear the text of a RadioButton control
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
            for (int i = 0; i < 3; i++)
            {
                // Check if current row has all cells marked by the player
                if (grid[i, 0] == player && grid[i, 1] == player && grid[i, 2] == player)
                {
                    // Add the result to the scores list based on the player who won
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
                    // Return true to indicate a winner has been found
                    return true;
                }
            }

            //Vertical checks
            for (int i = 0; i < 3; i++)
            {
                // Check if current column has all cells marked by the player
                if (grid[0, i] == player && grid[1, i] == player && grid[2, i] == player)
                {
                    // Add the result to the scores list based on the player who won
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
                    // Return true to indicate a winner has been found
                    return true;
                }
            }

            //Forward diagonal check
            if (grid[0, 0] == player && grid[1, 1] == player && grid[2, 2] == player)
            {
                // Add the result to the scores list based on the player who won
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
                // Return true to indicate a winner has been found
                return true;
            }

            //Backward diagonal check
            if (grid[0, 2] == player && grid[1, 1] == player && grid[2, 0] == player)
            {
                // Add the result to the scores list based on the player who won
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
                // Return true to indicate a winner has been found
                return true;
            }

            // If no winner has been found, return false
            return false;
        }

        #endregion

        #region Button Click Handlers
        private void ScoreboardBtn_Click(object sender, EventArgs e)
        {
            ScoreboardWindow score = new ScoreboardWindow(scores);
            score.ShowDialog();
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

            RadioButton buttonToChange = (RadioButton) ButtonGrid[x, y];

            if ((string)buttonToChange.Tag == "false")
                buttonToChange.Text = buttonText.ToString();

            buttonToChange.FlatAppearance.BorderColor = borderColor;
            buttonToChange.FlatAppearance.BorderSize = borderSize;

        }

        private void Button0_0_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(0, 0, Color.Crimson, 3, mySymbol);
        }

        private void Button0_0_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(0, 0, Color.White, 1, ' ');
        }

        private void Button0_1_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(0, 1, Color.Crimson, 3, mySymbol);
        }

        private void Button0_1_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(0, 1, Color.White, 1, ' ');
        }

        private void Button0_2_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(0, 2, Color.Crimson, 3, mySymbol);
        }

        private void Button0_2_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(0, 2, Color.White, 1, ' ');
        }

        private void Button1_0_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(1, 0, Color.Crimson, 3, mySymbol);
        }

        private void Button1_0_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(1, 0, Color.White, 1, ' ');
        }

        private void Button1_1_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(1, 1, Color.Crimson, 3, mySymbol);
        }

        private void Button1_1_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(1, 1, Color.White, 1, ' ');
        }

        private void Button1_2_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(1, 2, Color.Crimson, 3, mySymbol);
        }

        private void Button1_2_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(1, 2, Color.White, 1, ' ');
        }

        private void Button2_0_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(2, 0, Color.Crimson, 3, mySymbol);
        }

        private void Button2_0_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(2, 0, Color.White, 1, ' ');
        }

        private void Button2_1_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(2, 1, Color.Crimson, 3, mySymbol);
        }

        private void Button2_1_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(2, 1, Color.White, 1, ' ');
        }

        private void Button2_2_MouseEnter(object sender, EventArgs e)
        {
            HoverButton(2, 2, Color.Crimson, 3, mySymbol);
        }

        private void Button2_2_MouseLeave(object sender, EventArgs e)
        {
            HoverButton(2, 2, Color.White, 1, ' ');
        }

        #endregion

        
    }
}
