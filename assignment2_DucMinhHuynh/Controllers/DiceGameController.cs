using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace assignment2_DucMinhHuynh.Controllers
{
    public class DiceGameController : ApiController
    {
        /// <summary>
        ///     Create HTTP GET request , set up route api/J2/DiceGame/{first_dice}/{second_dice} , and
        ///     Take 2 agurments runing through 2 For loops. 
        ///     first_dice will take each element running For loop with second_dice length.
        ///     if each element does not have Sum equal to 10 , move next if it is equal to 10 , way++ and break.
        ///     Move next element in first_dice. 
        ///     After 2 For loops, print out number of Way .
        /// </summary>
        /// <param name="first_dice">6</param>
        /// <param name="second_dice">8</param>
        /// <returns>"There are 5 ways to get the sum 10."</returns>
        [HttpGet]
        [Route("api/J2/DiceGame/{first_dice}/{second_dice}")]
        public string DiceGameCompute(int first_dice , int second_dice) {
            int way = 0;
                for(int i = 1; i <= first_dice; i++)
                {
                    for(int y= 1; y <= second_dice; y++)
                    {
                        if(i + y == 10)
                    {
                        way++;
                        break;
                    }
                        else {
                        continue;
                        }
                    }
                }
            return "There are" + way.ToString() + "ways to get the sum 10.";
        }
    }
}
