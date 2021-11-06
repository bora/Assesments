using Xunit;

public class UnitTest
{
    [Fact]
    public void TestOkForLandingForBorderMaxXY()
    {
         var landObj = new Rocket.LandingHelper(7,7,20);
         var returnString = landObj.Process(26,26);
         Assert.Equal("ok for landing",returnString);
    }

    [Fact]
    public void TestOkForLandingForBorderMaxXMinY()
    {
         var landObj = new Rocket.LandingHelper(7,7,20);
         var returnString = landObj.Process(26,7);
         Assert.Equal("ok for landing",returnString);
    }

    [Fact]
    public void TestOkForLandingForBorderMinXMaxY()
    {
         var landObj = new Rocket.LandingHelper(7,7,20);
         var returnString = landObj.Process(7,26);
         Assert.Equal("ok for landing",returnString);
    }

    [Fact]
    public void TestOkForLandingForBorderMinXY()
    {
         var landObj = new Rocket.LandingHelper(7,7,20);
         var returnString = landObj.Process(7,7);
         Assert.Equal("ok for landing",returnString);
    }

    [Fact]
    public void TestOutOfPlatformBigger()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         var returnString = landObj.Process(20,19);
         Assert.Equal("out of platform",returnString);
    }

    [Fact]
    public void TestOutOfPlatformSmaller()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         var returnString = landObj.Process(6,6);
         Assert.Equal("out of platform",returnString);
    }

    [Fact]
    public void TestClashForSameCoordinates()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         landObj.Process(10,10);
         var returnString = landObj.Process(10,10);
         Assert.Equal("clash",returnString);
    }

    [Fact]
    public void TestClashForNeighbourCoordinates()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         landObj.Process(10,10);
         var returnString = landObj.Process(11,11);
         Assert.Equal("clash",returnString);
    }

    [Fact]
    public void TestClashForNeighbourCoordinatesNo2()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         landObj.Process(10,10);
         var returnString = landObj.Process(9,9);
         Assert.Equal("clash",returnString);
    }

    [Fact]
    public void TestClashForNeighbourCoordinatesNo3()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         landObj.Process(10,10);
         var returnString = landObj.Process(10,11);
         Assert.Equal("clash",returnString);
    }

    [Fact]
    public void TestClashForNeighbourCoordinatesNo4()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         landObj.Process(10,10);
         var returnString = landObj.Process(11,10);
         Assert.Equal("clash",returnString);
    }

    [Fact]
    public void TestClashForNeighbourCoordinatesNo5()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         landObj.Process(10,10);
         var returnString = landObj.Process(9,10);
         Assert.Equal("clash",returnString);
    }

    [Fact]
    public void TestClashForNeighbourCoordinatesNo6()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         landObj.Process(10,10);
         var returnString = landObj.Process(10,9);
         Assert.Equal("clash",returnString);
    }

    [Fact]
    public void TestClashForNeighbourCoordinatesNo7()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         landObj.Process(10,10);
         var returnString = landObj.Process(11,9);
         Assert.Equal("clash",returnString);
    }

    [Fact]
    public void TestClashForNeighbourCoordinatesNo8()
    {
         var landObj = new Rocket.LandingHelper(7,7,10);
         landObj.Process(10,10);
         var returnString = landObj.Process(9,11);
         Assert.Equal("clash",returnString);
    }

    [Fact]
    public void ThreeRocketsHealthyLanding()
    {
         bool returnBoolNo1;
         bool returnBoolNo2;
         bool returnBoolNo3;
         var landObj = new Rocket.LandingHelper(6,6,15);
         returnBoolNo1 = "ok for landing" == landObj.Process(10,10);
         returnBoolNo2 = "ok for landing" == landObj.Process(12,10);
         returnBoolNo3 = "ok for landing" == landObj.Process(14,10);
         Assert.True(returnBoolNo1 && returnBoolNo2 && returnBoolNo3);
    }

    [Fact]
    public void ThreeRocketsHealthyLandingVertical()
    {
         bool returnBoolNo1;
         bool returnBoolNo2;
         bool returnBoolNo3;
         var landObj = new Rocket.LandingHelper(6,6,15);
         returnBoolNo1 = "ok for landing" == landObj.Process(10,10);
         returnBoolNo2 = "ok for landing" == landObj.Process(10,12);
         returnBoolNo3 = "ok for landing" == landObj.Process(10,14);
         Assert.True(returnBoolNo1 && returnBoolNo2 && returnBoolNo3);
    }
}