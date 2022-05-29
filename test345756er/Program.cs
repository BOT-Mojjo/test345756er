using System;
using Raylib_cs;


Random rainPos = new Random(1270);

//array för Rain klassen
Rain[] rain =  new Rain[1000];


//for loop som ger varje regndroppe en slumpad position
for(int i = 0; i < rain.Length; i++)
{
    rain[i] = new Rain(rainPos.Next(1270), rainPos.Next(720));

}

//Raylib fönstret
Raylib.InitWindow(1270, 720, "SlutProjekt");
while(!Raylib.WindowShouldClose()){
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);

    //for loop som ritar en redtangel i raylib fönstret för varje nummer i rain arrayen
    for(int i = 0; i < rain.Length; i++)
    {
        Raylib.DrawRectangleRec(rain[(i)].raindrop, Color.BLUE);
        rain[i].rainfall();
    }



    Raylib.EndDrawing();
}

class Rain
{

    public int xOffset; 
    public int yOffset;
    public Rectangle raindrop = new Rectangle(); //själva droppens information

    //metod som hämtar de slumpade positionerna och binder dem till varsinn droppe
    //position och storlek av varje droppe
    public Rain(int _xOffset, int _yOffset)
    {
        xOffset = _xOffset;
        yOffset = _yOffset;
        raindrop = new Rectangle(_xOffset, _yOffset, 1, 3);
    }


    public void rainfall(){
        //ger alla regndroppar en hastighet nedåt.
        yOffset++;
        raindrop = new Rectangle(xOffset, yOffset, 1, 3);

        //if sats som flyttar regndroppen högst upp när den nått botten
        if(yOffset > 720)
        {
            yOffset = 0;
        }
    }

}