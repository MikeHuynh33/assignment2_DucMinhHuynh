using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace assignment2_DucMinhHuynh.Controllers
{
    public class MenuController : ApiController
    {
        /// <summary>
        ///     Create HTTP GET request , set up route api/J1/Menu/{burger}/{drink}/{side}/{dessert} , and
        ///     Take 4 agurments runing through Switch loop if input meet any conditions .
        ///     Check each value if it is valid (1 - 4), else add message into errorMessage. if the valid input will add totalCalories according to the list of colories items.
        ///     The listOfItems will collect the item for each categories.
        ///     Return total calories if errorMessage is empty. Otherwise return error message.
        /// </summary>
        /// <param name="burger">1</param>
        /// <param name="drink">2</param>
        /// <param name="side">3</param>
        /// <param name="dessert">4</param>
        /// <returns>Your total calorie count is 691</returns>
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string calculateTotalCalories(int burger, int drink , int side , int dessert)
        {
            int totalCalories = 0;
            string[] listOfItems = new string[4];
            string output = "";
            string errorMessage = string.Empty; 
            if(burger <= 4 && burger > 0)
            {
                switch (burger)
                {
                    case 1: totalCalories += 461;
                        listOfItems[0] = "(Cheeseburger)";
                        break;
                    case 2: totalCalories += 431;
                        listOfItems[0] = "(Fish Burger)";
                        break;
                    case 3: totalCalories += 420;
                        listOfItems[0] = "(Veggie Burger)";
                        break;
                    case 4: 
                        listOfItems[0] = "(no burger)";
                        break;
                    default:
                        errorMessage += "Buger value invalid ? ";
                        break;
                }
            };
            if (drink <= 4 && drink > 0)
            {
                switch (drink)
                {
                    case 1:
                        totalCalories += 130;
                        listOfItems[1] = "(Soft Drink)";
                        break;
                    case 2:
                        totalCalories += 160;
                        listOfItems[1] = "(Orange Juice)";
                        break;
                    case 3:
                        totalCalories += 118;
                        listOfItems[1] = "(Milk)";
                        break;
                    case 4:
                      
                        listOfItems[1] = "(no drink)";
                        break;
                    default:
                        errorMessage += "Drink value invalid ? ";
                        break;
                }
            };
            if (side <= 4 && side > 0)
            {
                switch (side)
                {
                    case 1:
                        totalCalories += 100;
                        listOfItems[2] = "(Fries)";
                        break;
                    case 2:
                        totalCalories += 57;
                        listOfItems[2] = "(Baked Potato)";
                        break;
                    case 3:
                        totalCalories += 70;
                        listOfItems[2] = "(Chef Salad)";
                        break;
                    case 4:
                        listOfItems[2] = "(no side order)";
                        break;
                    default:
                        errorMessage += "Side value invalid ? ";
                        break;
                }
            };
            if (dessert <= 4 && dessert > 0)
                {
                    switch (dessert)
                    {
                        case 1:
                            totalCalories += 167;
                            listOfItems[3] = "(Apple Pie)";
                            break;
                        case 2:
                            totalCalories += 266;
                            listOfItems[3] = "(Sundae)";
                            break;
                        case 3:
                            totalCalories += 75;
                            listOfItems[3] = "(Fruit Cup)";
                            break;
                        case 4:
                            listOfItems[3] = "(No Dessert)";
                            break;
                        default:
                            errorMessage += "Dessert value invalid ? ";
                            break;
                }
             }
            foreach(string item in listOfItems)
            {
                output += item + "-";
            }
            if (errorMessage != " ")
            {
                return errorMessage;
            }
            else
            {
                return output + " Your total calorie count is " + totalCalories;
            }
            
        }
    }
}
