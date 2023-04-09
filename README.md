# Tic Tac Toe using TCP

Welcome to my desktop Tic Tac Toe application! It's designed to be a simple, easy to play, and lightweight application that lets you and your friend dish it out in a series of rounds to determine the ultimate Tic Tac Toe master!

## Features

 - Playable online over a LAN connection using TCP sockets.
 - Supported by any Windows PC, no beefy system requirements.
 - Both players fully color coded (Player 1 in Red, Player 2 in Blue)
 - Game setup screen before the match starts
 - Scoreboard that updates after every round and every match
 - Play a tournament, best of N rounds wins (you decide the N!)

## How to Play

It's simple! Here's step-by-instructions for setting up and playing a turn of the game, from the perspective of Player 1 (Host) and Player 2 (Client):
### Player 1 Instructions

 1. Launch the game, and you are immediately greeted with the game set
    up screen.
 2. As Player 1, you get to choose which symbol to play as and how many rounds to play.
 Click **'Confirm'** when you are ready.
 3. You must now establish a TCP connection with the client. Enter a port in the Port text box and click **'Start Listening'** (you can also just leave the port text box as is, start listening on Port 1234).
 4.  Wait for Player 2 to connect to you. Once they do, the match will immediately begin with Round 1.
 5. Click on a cell to mark it. You can change your choice at any time by simply clicking on another cell.
 6.  To confirm your move, click the send button. 
### Player 2 Instructions

 1. Launch the game.
 2. You must now establish a TCP connection with the server, who should already be listening for you. 
 3. Enter the server's IP Address and Port in the text box (separated by ':'), and click **'Connect'** to connect to the server. For playing on the same machine, use the local host loopback IP of '127.0.0.1'.
 4. Once connected, the match should immediately begin with Round 1.
 5. Click on a cell to mark it. You can change your choice at any time by simply clicking on another cell.
 6. To confirm your move, click the send button. 

## Game Rules
The rules are simple and easy to learn. Most of you playing this game are probably already well-acquainted with them, but for those who aren't, I'll go over them here:

 - Each player must take turns placing their symbol down on the 3x3 grid
 - The goal of the game is to place down 3 symbols in a row, either horizontally, vertically, or diagonally.
 - The first player who manages to complete a line of 3 symbols wins the round!
 - If the board fills up without any player completing a line of 3, the round is a draw!
 - To win the entire match, you must win the best of all N rounds!


