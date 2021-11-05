using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingLandingPoint = 5;
            int size = 10;
            var landObj = new LandingHelper(startingLandingPoint,size);
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

        public int EndingLandingPoint { get; set; }

        public int StartingLandingPoint { get; set; }

        public int ArraySize { get; set; }

        public bool[,] LandPlatformArray { get; set; } 

        public LandingHelper(int startingPoint, int size){

            if (startingPoint + size > LandingArea )
                throw new ArgumentNullException("Landing platform should be inside landing area!");

            ArraySize = size;
            EndingLandingPoint = startingPoint + size;
            StartingLandingPoint = startingPoint;
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
            if(posX >= EndingLandingPoint || posX < StartingLandingPoint ||
                posY >= EndingLandingPoint || posY < StartingLandingPoint)
                return "out of platform";

            int x = posX - StartingLandingPoint;
            int y = posY - StartingLandingPoint;
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
