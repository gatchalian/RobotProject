using System;
using System.Collections.Generic;
using System.Text;

namespace RobotSimulatorLibrary
{
    public class StringConstants
    {
        //error messages
        public static string PlaceCommandNotValid = "Place command parameters not valid.\r\nUsage:PLACE 0,0,NORTH";
        public static string RobotNotInPlace = "robot not in table, please do PLACE command.";

        //command strings
        public static string Place = "PLACE";
        public static string Move = "MOVE";
        public static string Left = "LEFT";
        public static string Right = "RIGHT";
        public static string Report = "REPORT";
    }
}
