# Introducing Blazor Web Applications

Today we're going to learn how to build a Blazor app by recreating the classic four-in-a-row game, Connect Four.

## What is Blazor?

Blazor is a framework for building web pages with HTML, CSS, and C#. We can define the layout and design of the website using standard HTML and CSS. The interactive components of the web pages can then be managed with C# code that runs on a server or in the browser using a web standard technology called WebAssembly. Blazor allows us to define our web pages and components using Razor syntax, a convenient mixture of HTML and C#. You can easily reuse Blazor components inside other pages and components. This capability means we can build and reuse parts of our app easily.

## What is WebAssembly?

WebAssembly is a standard technology available in every modern browser that allows code to run, similar to JavaScript, in a browser. We can use tools to prepare our C# code for use in the browser as a WebAssembly app, and these tools are included with the .NET SDK.

## Structure of this repository

We're including all of the layout and game logic in this repository as well as a completed sample Blazor Connect Four app to compare your progress with.  We'll walk through the initial construction of the application using the .NET command-line, and you can find an instance of that code with the CSS and game logic in the [0-start](0-start) folder of this repository.  The completed state of the game can be found in the [1-complete](1-complete) folder.

## What we're building

This repository will walk you through Blazor and introduce the following concepts:

- Blazor component fundamentals
- How to get started with the Blazor Web App project template
- How to construct and use a layout for a Blazor component
- How to react to user interactions

We accomplish the above goals by writing a classic four-in-a-row "Connect Four" game that runs in your browser.  In this game, 2 players alternate taking turns placing a gamepiece (typically a checker) in the top of the board.  Game pieces fall to the lowest row of a column and the player that places 4 game pieces to make a line horizontally, vertically, or diagonally wins.

## Create a new Blazor project

First, let's scaffold a new project for our game.

**GitHub Codespaces Instructions** 

1. Open a GitHub Codespace. To do this, simply select the green **Code** button. Then click the **+** to create a Codespace on the main branch.
2. Navigate to the project files in the [0-start folder](0-start)

**Visual Studio Instructions**

1. Create a new Blazor app in Visual Studio 2022 by choosing the **File > New > Project** menu.

1. Choose "Blazor Web App" from the list of templates and name it "ConnectFour". Select **Next**.

1. Choose .NET 8 for the framework version. The Authentication type should be set to **None**, Interactive render mode should be set to **Server**, and Interactivity location should be set to **Per page/component**. Leave all other options as the defaults.

    This action should create a ConnectFour directory containing our app.

1. Run the app by pressing <kbd>F5</kbd> in Visual Studio 2022.

    You should now see the Blazor app running in your browser:

    ![Screenshot from the new Blazor Template](img/1-NewTemplate.png)

Congratulations! You've created your first Blazor app!

## Create a board component

Next, let's create a game board component to be used by players in our game. The component is defined using Razor syntax, which is a mix of HTML and C#.

1. Right-click on the *Components* folder in the Solution Explorer of Visual Studio. Choose **Add > Razor Component** from the context menu and name the file *Board.razor*.

    We'll use this component to hold everything needed for the game-board layout and managing interactions with it. The initial contents of this new component are an `h3` tag and a `@code` block indicating where C# code should be written:

    ```razor
    <h3>Board</h3>
    
    @code {
    
    }
    ```

1. Prepare the `Home` page by opening the *Components/Pages/Home.razor* file and clearing out everything after the third line with the `PageTitle`` tag.

    ```razor
    @page "/"
    
    <PageTitle>Home</PageTitle>
    ```

1. Add our `Board` component to the `Home` page by adding a `<Board />` tag, which matches the filename of our new component.

    ```razor
    @page "/"
    
    <PageTitle>Index</PageTitle>
    <Board />
    ```

    The *Home.razor* file is a component that can be navigated to from a web browser. It contains HTML, C#, and references to other Blazor components. We can identify this file as a page due to the presence of the `@page "/"` directive on the first line. This directive assigns the "/" route to the component and instructs Blazor to respond with the contents of this file when the default page at the "/" address is requested.

1. Run the app with F5 to see the changes. If the app is already running, tap the Hot Reload button next to the Run/Continue button to apply the changes to the running app.

    > TIP: Select the **Hot Reload on File Save** option from the Hot Reload menu to apply changes to the running app whenever you change a file.

    ![The initial Board component displayed on the Home page](img/2-Board-Step1.png)

Congratulations! You've built your first component and used it on a Blazor page.

## Adding content and style to the game board

Blazor components contain all of the HTML and markup needed to be rendered in a web browser. Let's start defining a game board with the seven columns and six rows. We'll add a little style to bring our board to life.

1. In the *Board.razor* file, remove the HTML at the top and add the following content to define a board with 42 places for game pieces.

    We can use a C# `for` loop to generate the 42 board positions. The container `span` tag is picked up and repeated with its contents 42 times to represent our board.

    ```razor
    <div>
       <div class="board">
          @for (var i = 0; i < 42; i++)
          {
             <span class="container">
                <span></span>
             </span>
          }
       </div>
    </div>
    `````

When we save the board component, our app refreshes and it appears as an empty page, thanks to the Hot Reload functionality that rebuilds and launches the updated app.

> [!NOTE]
> You may be prompted by Visual Studio to restart your app as files change. Confirm that the app should be rebuilt on code edits, and the app will automatically restart and refresh the browser as you add features.

### Styling the component

Let's add some style to the `Board` component by defining some colors for the frame of the board and the players above the first `div` tag in the *Board.razor* file:

```razor
<HeadContent>
    <style>
        :root {
            --board-bg: yellow;  /** the color of the board **/
            --player1: red;      /** Player 1's piece color **/
            --player2: blue;     /** Player 2's piece color **/
        }
    </style>
</HeadContent>

<div>...</div>
```

These CSS variables `--board-bg`, `--player1: red`, `--player2: blue` will be picked up and used in the rest of our stylesheet for this component.

Next, we'll add a completed stylesheet for the game to the `Board` component.

1. Right-click in the Solution Explorer on the *Components* folder and create a new CSS file called *Board.razor.css*.

1. Copy the following content into the new *Board.razor.css* file:

    ```css
    div{position:relative}nav{top:4em;width:30em;display:inline-flex;flex-direction:row;margin-left:10px}nav span{width:4em;text-align:center;cursor:pointer;font-size:1em}div.board{margin-top:1em;flex-wrap:wrap;width:30em;height:24em;overflow:hidden;display:inline-flex;flex-direction:row;flex-wrap:wrap;z-index:-5;row-gap:0;pointer-events:none;border-left:10px solid var(--board-bg)}span.container{width:4em;height:4em;margin:0;padding:4px;overflow:hidden;background-color:transparent;position:relative;z-index:-2;pointer-events:none}.container span{width:3.5em;height:3.5em;border-radius:50%;box-shadow:0 0 0 3em var(--board-bg);left:0;position:absolute;display:block;z-index:5;pointer-events:none}.player1,.player2{width:3.5em;height:3.5em;border-radius:50%;left:0;top:0;position:absolute;display:block;z-index:-8}.player1{background-color:var(--player1);animation-timing-function:cubic-bezier(.5,.05,1,.5);animation-iteration-count:1;animation-fill-mode:forwards;box-shadow:0 0 0 4px var(--player1)}.player2{background-color:var(--player2);animation-timing-function:cubic-bezier(.5,.05,1,.5);animation-iteration-count:1;animation-fill-mode:forwards;box-shadow:0 0 0 4px var(--player2)}.col0{left:calc(0em + 9px)}.col1{left:calc(4em + 9px)}.col2{left:calc(8em + 9px)}.col3{left:calc(12em + 9px)}.col4{left:calc(16em + 9px)}.col5{left:calc(20em + 9px)}.col6{left:calc(24em + 9px)}.drop1{animation-duration:1s;animation-name:drop1}.drop2{animation-duration:1.5s;animation-name:drop2}.drop3{animation-duration:1.6s;animation-name:drop3}.drop4{animation-duration:1.7s;animation-name:drop4}.drop5{animation-duration:1.8s;animation-name:drop5}.drop6{animation-duration:1.9s;animation-name:drop6}@keyframes drop1{100%,75%,90%,97%{transform:translateY(1.27em)}80%{transform:translateY(.4em)}95%{transform:translateY(.8em)}99%{transform:translateY(1em)}}@keyframes drop2{100%,75%,90%,97%{transform:translateY(5.27em)}80%{transform:translateY(3.8em)}95%{transform:translateY(4.6em)}99%{transform:translateY(4.9em)}}@keyframes drop3{100%,75%,90%,97%{transform:translateY(9.27em)}80%{transform:translateY(7.2em)}95%{transform:translateY(8.3em)}99%{transform:translateY(8.8em)}}@keyframes drop4{100%,75%,90%,97%{transform:translateY(13.27em)}80%{transform:translateY(10.6em)}95%{transform:translateY(12em)}99%{transform:translateY(12.7em)}}@keyframes drop5{100%,75%,90%,97%{transform:translateY(17.27em)}80%{transform:translateY(14em)}95%{transform:translateY(15.7em)}99%{transform:translateY(16.5em)}}@keyframes drop6{100%,75%,90%,97%{transform:translateY(21.27em)}80%{transform:translateY(17.4em)}95%{transform:translateY(19.4em)}99%{transform:translateY(20.4em)}}
    ```

    For convenience, you can also find this content in the [0-start/Shared/Board.razor.css](0-start/Shared/Board.razor.css) file in this repository.

    Blazor components and pages have a feature called CSS isolation that allows you to create style rules that will only be applied to the contents of that component or page.  By creating a file with the same name as our component and adding the `.css` filename extension, Blazor will recognize this as the styles that should **ONLY** be applied to HTML content in the `Board` component.

    Here's some of the CSS used to format the board and "punch holes" for each of the spaces. There's more content available than displayed below in the CSS file for the game pieces and their animations on screen.

    ```css
    div.board {
        margin-top: 1em;
        flex-wrap: wrap;
        width: 30em;
        height: 24em;
        overflow: hidden;
        display: inline-flex;
        flex-direction: row;
        flex-wrap: wrap;
        z-index: -5;
        row-gap: 0;
        pointer-events: none;
        border-left: 10px solid var(--board-bg);
    }
    
    span.container {
        width: 4em;
        height: 4em;
        margin: 0;
        padding: 4px;
        overflow: hidden;
        background-color: transparent;
        position: relative;
        z-index: -2;
        pointer-events: none;
    }
    
    .container span {
        width: 3.5em;
        height: 3.5em;
        border-radius: 50%;
        box-shadow: 0 0 0 3em var(--board-bg);
        left: 0px;
        position: absolute;
        display: block;
        z-index: 5;
        pointer-events: none;
    }
    ```

The browser should update for you (if not, you can manually refresh the browser with F5), and you should be greeted with a proper yellow Connect Four board:

![The first appearance of a yellow Connect Four board on screen](img/2-Board-Step2.png)

## Introducing game logic and controls

The game logic for Connect Four is not too difficult to program.  We need some code that will manage the state of the game and identify 4 consecutive game pieces played next to each other and announce the winner.  To help keep this tutorial on-topic with teaching about Blazor, we are providing a class called `GameState.cs` that contains the logic for managing the game.

The [GameState.cs file is in this repository](1-complete/ConnectFour/Shared/GameState.cs) and you will copy it into your version of the game.

1. Copy the [GameState.cs file](1-complete/ConnectFour/Shared/GameState.cs) from this repository into the root of your project.

We need to make an instance of the `GameState` available to any component that requests it, and only one instance of `GameState` should be available in our app at a time.  We'll address this need by registering our `GameState` as a singleton service in the app.

1. Open the *Program.cs* file at the root of the project and add this statement to configure `GameState` as a singleton service in your app:

    ```csharp
    builder.Services.AddSingleton<GameState>();
    ```

    We can now inject an instance of the `GameState` class into our `Board` component.

1. Add the following `@inject` directive at the top of the *Board.razor* file to inject the current state of the game into the component:

    ```razor
    @inject GameState State
    ```

    We can now start connecting our `Board` component to the state of the game.

## Reset state

Let's begin by resetting the state of the game when the `Board` component is first painted on screen. We'll add some code to reset the state of the game when the component is initialized.

1. Add an `OnInitialized` method with a call to `ResetBoard`, inside the `@code` block at the bottom of the *Board.razor* file, like so:

    ```razor
    @code {
        protected override void OnInitialized()
        {
            State.ResetBoard();
        }
    }
    ```

    When the board is first shown to a user, the state is reset to the beginning of a game.

## Create game pieces

Next, let's allocate the possible 42 game pieces that could be played. We can represent the game pieces as an array referenced by 42 HTML elements on the board. We can move and place those pieces by assigning a set of CSS classes with column and row positions.

1. Define an string array field in the code block to hold our game pieces:

    ```razor
    private string[] pieces = new string[42];
    ```

1. Add code to the HTML section that creates 42 `span` tags, one for each game piece, in the same component:

    ```razor
    @for (var i = 0; i < 42; i++)
    {
       <span class="@pieces[i]"></span>
    }
    ```

    Your full code should look like so:

    ```razor
    <div>
        <div class="board">...</div>
        @for (var i = 0; i < 42; i++)
        {
           <span class="@pieces[i]"></span>
        }
    </div>
    @code {
        private string[] Pieces = new string[42];
    
        protected override void OnInitialized()
        {
            State.ResetBoard();
        }
    }
    ```

    This assigns an empty string to the CSS class of each game piece span. An empty string for a CSS class prevents the game pieces from appearing on screen as no style is applied to them.

## Handle game piece placement

Let's add a method to handle when a player places a piece in a column. The `GameState` class knows how to assign the correct row for the game piece, and reports back the row that it lands in. We can use this information to assign CSS classes representing the player's color, the final location of the piece, and a CSS drop animation.

We call this method `PlayPiece`, and it accepts an input parameter that specifies the column the player has chosen.

1. Add this code below the `pieces` array we defined in the previous step.

    ```csharp
    private void PlayPiece(byte col)
    {
        var player = State.PlayerTurn;
        var turn = State.CurrentTurn;
        var landingRow = State.PlayPiece(col);
        pieces[turn] = $"player{player} col{col} drop{landingRow}";
    }
    ```

Here's what the `PlayPiece` code does:

1. We tell the game state to play a piece in the submitted column called `col` and capture the row the piece landed in.
1. We can then define the three CSS classes to assign to the game piece to identify which player is currently acting, the column the piece was placed in, and the landing row.
1. The last line of the method assigns these classes to that game piece in the `pieces` array.

If you look in the supplied *Board.razor.css*, you'll find the CSS classes matching column, row, and player turn.

The resultant effect is that the game piece is placed in the column and animated to drop into the bottom-most row when this method is called.

## Choosing a column

We next need to place some controls that allow players to choose a column and call our new `PlayPiece` method. We'll use the "🔽" character to indicate that you can drop a piece in this column.

1. Above the starting `<div>` tag, add a row of clickable buttons:

    ```html
    <nav>
        @for (byte i = 0; i < 7; i++)
        {
            var piece = i;
            <span title="Click to play a piece" @onclick="() => PlayPiece(piece)">🔽</span>
        }
    </nav>
    ```

    The `@onclick` attribute specifies an event handler for the click event. But to handle UI events, a Blazor component needs to be rendered using an *interactive render mode*. By default, Blazor components are rendered statically from the server. We can apply an interactive render mode to a component using the `@rendermode` attribute.

1. Update the `Board` component on the `Home` page to use the `InteractiveServer` render mode.

    ```razor
    <Board @rendermode="InteractiveServer" />
    ```

    The `InteractiveServer` render mode will handle UI events for your components from the server over a WebSocket connection with the browser.

1. Run the app with these changes. It should look like this now:

    ![Yellow Game Board with drop buttons at the top](img/2-Board-Step3.png)

    Even better, when we select one of the drop buttons at the top, the following behavior can be observed:

    ![First piece dropped into board](img/2-board-drop.gif)

Great progress! We can now add pieces to the board. The `GameState` object is smart enough to pivot back and forth between the two players. Go ahead and select more drop buttons and watch the results.

## Winning and error handling

If you play with the game that you've configured at this point, you'll find that it raises errors when you try to put too many pieces in the same column and when one player has won the game.

Let's add some error handling and indicators to our board to make the current state clear. We'll add a status area above the board and below the drop buttons.

1. Insert the following markup after the `nav` element:

    ```razor
    <nav>...</nav>
    
    <article>
        @winnerMessage  <button style="@ResetStyle" @onclick="ResetGame">Reset the game</button>
        <br />
        <span class="alert-danger">@errorMessage</span>
        <span class="alert-info">@CurrentTurn</span>
    </article>
    ```

    This markup allows us to display indicators for:

    - Announcing a game winner
    - A button that allows us to restart the game
    - Error messages
    - The current player's turn

    Let's fill in some logic to set these values.

1. Add the following code after the pieces array:

    ```csharp
    private string[] pieces = new string[42];
    private string winnerMessage = string.Empty;
    private string errorMessage = string.Empty;
    
    private string CurrentTurn => (winnerMessage == string.Empty) ? $"Player {State.PlayerTurn}'s Turn" : "";
    private string ResetStyle => (winnerMessage == string.Empty) ? "display: none;" : "";
    ```

    - The `CurrentTurn` property is automatically calculated based on the state of the `winnerMessage` and the `PlayerTurn` property of the `GameState`.
    - The `ResetStyle` is calculated based on contents of the `winnerMessage`. If there's a `winnerMessage`, we make the reset button appear on screen.

1. Let's handle the error message when a piece is played. Add a line to clear the error message and then wrap the code in the `PlayPiece` method with a `try...catch` block to set the `errorMessage` if an exception occurred:

    ```csharp
    errorMessage = string.Empty;
    try
    {
        var player = State.PlayerTurn;
        var turn = State.CurrentTurn;
        var landingRow = State.PlayPiece(col);
        pieces[turn] = $"player{player} col{col} drop{landingRow}";
    }
    catch (ArgumentException ex)
    {
        errorMessage = ex.Message;
    }
    ```

    Our error handler indicator is simple and uses the Bootstrap CSS framework to display an error in danger mode.

    ![Game board with an error indicating the column is full](img/3-Board-ErrorHandler.png)

1. Next, let's add the `ResetGame` method that our button triggers to restart a game. Currently, the only way to restart a game is to refresh the page. This code allows us to stay on the same page.

    ```csharp
    void ResetGame()
    {
        State.ResetBoard();
        winnerMessage = string.Empty;
        errorMessage = string.Empty;
        pieces = new string[42];
    }
    ```

    Now our `ResetGame` method has the following logic:

    - Reset the state of the board.
    - Hide our indicators.
    - Reset the pieces array to an empty array of 42 strings.

    This update should allow us to play the game again, and now we see an indicator just above the board declaring the player's turn and eventually the completion of the game.

    ![Game over with indicators](img/3-Board-Step1.png)

    We're still left in a situation where we can't select the reset button. Let's add some logic in the `PlayPiece` method to detect the end of the game.

1. Let's detect if there's a winner to the game by adding a switch expression after our `try...catch` block in `PlayPiece`.

    ```csharp
    winnerMessage = State.CheckForWin() switch
    {
        GameState.WinState.Player1_Wins => "Player 1 Wins!",
        GameState.WinState.Player2_Wins => "Player 2 Wins!",
        GameState.WinState.Tie => "It's a tie!",
        _ => ""
    };
    ```

    The `CheckForWin` method returns an enum that reports which player, if any has won the game or if the game is a tie. This switch expression will set the `winnerMessage` field appropriately if a game over state has occurred.

    Now when we play and reach a game-ending scenario, these indicators appear:

    ![Game board announcing winner with reset button](img/3-Board-Step2.png)

## Customizing the board with parameters

The game works, but maybe you don't like our default colors. In Blazor, we can define parameters on our components that allow us to pass in values that look like attributes on an HTML tag.

Let's add some parameters for the colors on the board, and pass in some groovy colors from the `Home` page.

Parameters in Blazor are properties on a component that have been decorated with the `Parameter` attribute.

1. In *Board.razor*, let's define three properties for the board color, and each player's color. Before the `OnInitialized`` method, add these lines of code:

    ```csharp
    [Parameter]
    public Color BoardColor { get; set; } = ColorTranslator.FromHtml("yellow");
    
    [Parameter]
    public Color Player1Color { get; set; } = ColorTranslator.FromHtml("red");
    
    [Parameter]
    public Color Player2Color { get; set; } = ColorTranslator.FromHtml("blue");
    ```

    We use the `Color` type to ensure that the values passed to our Board component are in-fact colors.

1. Add a `@using` directive to the top of the *Board.razor* file to indicate we're using content from the `System.Drawing` namespace.

    ```razor
    @using System.Drawing
    ```

1. Use the parameters in the CSS block at the top of *Board.razor* to set the values of the CSS variables.

    ```razor
    <HeadContent>
        <style>
            :root {
                --board-bg: @ColorTranslator.ToHtml(BoardColor);
                --player1: @ColorTranslator.ToHtml(Player1Color);
                --player2: @ColorTranslator.ToHtml(Player2Color);
            }
        </style>
    </HeadContent>
    ```

    This change shouldn't have changed anything in the appearance of our game board.

1. Let's head back to *Home.razor* and add some parameters to our `Board` tag and see how they change the game

    ```razor
    <Board @rendermode="InteractiveServer"
         BoardColor="System.Drawing.Color.Black"
         Player1Color="System.Drawing.Color.Green"
         Player2Color="System.Drawing.Color.Purple" />
    ```

    Isn't that a cool looking board?

    ![Connect 4 board with green and purple pieces](img/4-Board.png)

## Summary

We've learned a lot about Blazor and built a neat little game. Here are some of the skills we learned:

- Created a component
- Added that component to our home page
- Used dependency injection to manage the state of a game
- Made the game interactive with event handlers to place pieces and reset the game
- Wrote an error handler to report the state of the game
- Added parameters to our component

This is just a simple game, and there's so much more you could do with it.  Looking for some challenges to improve it?  Consider the following challenges:

- Remove the default layout and extra pages in the app to make it smaller.
- Improve the parameters to the `Board` component so that you can pass any valid CSS color value.
- Improve the indicators appearance with some CSS and HTML layout.
- Introduce sound effects.
- Add a visual indicator and prevent a drop button from being used when the column is full.
- Add networking capabilities so that you can play a friend in their browser.
- Insert the game into a .NET MAUI with Blazor application and play it on your phone or tablet.

Happy coding and have fun!

## Connect with us

We're excited to support you on your learning journey! Check out the [.NET Community Page](https://dotnet.microsoft.com/platform/community) to find links to our blogs, YouTube, Twitter, and more.

## How'd it go?

Please take this quick, [10 question survey](https://aka.ms/WebLearningSeries-git-survey) to give us your thoughts on this lesson & challenge!
