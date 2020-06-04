# Monopoly-CS-WPF
In this project an original "hardcore" version of the classic game, written in C#, is implemented. The goal was to implement the logic of Monopoly with new variations, using the MVC pattern. WPF and Visual studio ide were used to complete this project.  
<br> **About the idea** <br> An original fun version is implemented where
many old rules still aply, but there are a lot of new ones too, which make the game unpredictable. More about the rules in the section "Rules of the game".

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org) 
<img src="images/build_passing.svg" alt="Passing build">
<img src="https://img.shields.io/badge/windows-compatible-green.svg" alt="Windows compatible">


# Monopoly Hardcore Edition

<div align="center"><img src="images/image1.png" alt="image1"></div>

# Game Files and Demo

- The code with the ui elements, classes (models e.t.c.) and the assets are located in MonopolyGame folder.
- A windows executable is located at Monopoly_Executable folder.

# Rules of the game

### Extra (new) rules implemented in our “hardcore” edition

- When a player chooses to buy a property, there is a possibility that something will go wrong (for example a possibility to lose the money or meet a thief on the way). In that occasion the player loses the money of the property’s worth and takes nothing in return. (Unfortunate player). There is a 70% possibility that the player will buy the property and 30%, one of the “unfortunate” results to occur and cause the player to lose the money of the investment.
- There are no hotels. So players can only build houses.

<div align="center"><img src="images/image2.png" alt="image2"></div>

### And the old rules that still apply to this game

- 2-4 players can play.
- A game is played as a series of rounds. Each player takes a turn till a player wins or everybody except one player quits (1 player only is left).
- The players play on a board of specific squares (40 squares).
- Player moves to a new square by rolling two dice.
- After a player rolls the dice, UI elements like player’s name, square e.t.c. are displayed.
- The pieces are advanced clockwise around the board (equal to the sum of the 2 dice).
- The game board is circle, the “go” square in the beginning or the end of a round (1st square in the down, right corner) follows the 40th square on the board.
- A player can buy a property if the property is not owned and the player can afford to buy the property . If the player agrees to buy it, he/she pays the Bank the amount shown on the property space and receives the deed for that property. 
- A player can build a house when he/she owns every property of the same colour.
- If the player lands on or passes Go in the course of his or her turn, he or she receives $200 from the Bank. 
- A player pays taxes or another player if the square is owned by another player or it is a taxes square.
- If the player lands on his or her own property, or on property which is owned by another player but currently mortgaged, nothing happens.
- A player draws a card if a player lands on chances square or community chest.
- You may sell houses back to the Bank for half the purchase price or sell property deeds to other players in the game.
- Players may not loan money to other players. Only the Bank can loan money, and only through mortgaging properties
- If the player lands on the Jail space, he or she is "Just Visiting". No penalty applies.
- A player goes to jail where he has to pay fine if he/she draws the card “Go to jail” or rolls “doubles” for 3 times.
- If a player is sent to jail, he/she stays there for some rounds.

### And the old rules that do NOT apply to this game

<div align="center"><img src="images/not_apply.gif" alt="no gif"></div>

- A player CANNOT build a hotel when he/she has already purchased 4 houses in that property. This feauture was not implementes not because of it complexity 
but because it may give an advantage to the player who firsts builds more hotels and we don't want that in that version.
- Of course there are many versions of monopoly and more rules may not have been implemented.


## Copyright and License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
- Copyright 2020 © <a href="http://fvcproductions.com" target="_blank">NasosG</a>.


## Copyright claims
Some images used in the project belong to their respective creators/authors. No claim by me & those who use this project!!

**Thanks for reading**