using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingLandingPointX = 5;
            int startingLandingPointY = 8;
            int size = 10;
            var landObj = new LandingHelper(startingLandingPointX,startingLandingPointY,size);
            string returnString = string.Empty;
            returnString = landObj.Process(12,7);
            Console.WriteLine(returnString);
            landObj.PrintTwoDimensionalArray();
            returnString = landObj.Process(1,1);
            Console.WriteLine(returnString);
            returnString = landObj.Process(6,8);
            Console.WriteLine(returnString);
            landObj.PrintTwoDimensionalArray();
            returnString = landObj.Process(14,14);
            Console.WriteLine(returnString);
            landObj.PrintTwoDimensionalArray();
            //landObj.CreateLandingPlatformList(startingLandingPoint,size);
            Console.ReadKey();
            
        }
    }

    class LandingHelper
    {
        private readonly int landingArea = 100;
        public int LandingArea { get { return landingArea;}  }

        public int EndingLandingPointX { get; set; }

        public int EndingLandingPointY { get; set; }

        public int StartingLandingPointX { get; set; }

        public int StartingLandingPointY { get; set; }

        public int ArraySize { get; set; }

        public bool[,] LandPlatformArray { get; set; } 

        public LandingHelper(int startingPointX,int startingPointY, int size){

            if (startingPointX + size > LandingArea || startingPointY + size > LandingArea )
                throw new ArgumentNullException("Landing platform should be inside landing area!");

            ArraySize = size;
            EndingLandingPointX = startingPointX + size;
            EndingLandingPointY = startingPointY + size;
            StartingLandingPointX = startingPointX;
            StartingLandingPointY = startingPointY;
            LandPlatformArray = CreateLandingPlatformArray(size);
            //PrintTwoDimensionalArray();
        }

        public void PrintTwoDimensionalArray(){
            for (int i = 0; i < LandPlatformArray.GetLength(0); i++)
            {
                for (int j = 0; j < LandPlatformArray.GetLength(1); j++) {
                    Console.Write("{0} ", LandPlatformArray[i, j]);
                }
                Console.WriteLine();
            }
        }

        public string Process(int posX, int posY) {
            if(posX >= EndingLandingPointX || posX < StartingLandingPointX ||
                posY >= EndingLandingPointY || posY < StartingLandingPointY)
                return "out of platform";

            int x = posX - StartingLandingPointX;
            int y = posY - StartingLandingPointY;
            if( LandPlatformArray[ x , y] ){
                return "clash";
            }
            else{
                //LandPlatformArray[ x , y ] = true;
                SetSeperationPoints(x,y);
                return "ok for landing";
            }
        }

        private void SetSeperationPoints(int x, int y){
                
            for (int i = x-1; i <= x+1; i++)
            {
                 for (int j = y-1; j <= y+1; j++)
                 {
                    if(i >= 0 && i < ArraySize & j >= 0 && j < ArraySize)
                        LandPlatformArray[ j , i ] = true;
                }
            }
        }

        public bool[,] CreateLandingPlatformArray(int size){
                bool[,] landingPlatformArray = new bool[size,  size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j <  size; j++)
                    {
                        landingPlatformArray[i,j] = false;
                    }
                }
                return landingPlatformArray;
        }
    }
}
