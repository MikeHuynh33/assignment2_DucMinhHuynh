using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace assignment2_DucMinhHuynh.Controllers
{
    public class HarpTuningController : ApiController
    {
        /// <summary>
        ///     The Question was J3 CCC 2022 (https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2022/ccc/juniorEF.pdf)
        ///     I got into problem (The request filtering module is configured to deny a request that contains a double escape sequence. APS.NET)
        ///     In order to handling URL with double escape squence, I Inserted (<security><requestFiltering allowDoubleEscaping = "true" ></ requestFiltering ></ security >) inside Web.config
        /// </summary>
        /// <param name="harpTuning">AFB+8SC-4H-2GDPE+9</param>
        /// <returns> AFB tighten 8. | SC loosen 4. | H loosen 2. | GDPE tighten 9. | </returns>
        [HttpGet]
        [Route("api/J3/HarpTuning/{harpTuning}")]
        public string HarpTuning(string harpTuning)
        {
             List<string > listOfInstruction = new List<string>();
             List<string> listOfTune = new List<string>();
             string temp_intruction = "";
            string outputMessage = "";
            string temp_tune = "";
          
            for (int i = 0; i < harpTuning.Length; i++)
            {
                // if element is letter , add that letter into temp_intruction.
                if (Char.IsLetter(harpTuning[i]))
                {
                    temp_intruction += harpTuning[i];
                }
                else if (Char.IsLetter(harpTuning[i]) == false && Char.IsNumber(harpTuning[i]) == false){
                    if (harpTuning[i].ToString() == "+" || harpTuning[i].ToString() == "-")
                    {
                        // if loop hit "-" or "+" start add temp_intruction into listOfIntruction List and set temp_intruction back to empty, waiting for next letter element. 
                        listOfInstruction.Add(temp_intruction);
                        temp_intruction = "";
                        // if loop element hit + or - start adding it on temp_tune
                        temp_tune += harpTuning[i];
                        // run loop to see how many number elements until it hit letter element. start from next element y = i + 1;
                        for ( int y = i + 1; y < harpTuning.Length ; y++)
                        {
                            //
                            if (Char.IsNumber(harpTuning[y]))
                            {
                                temp_tune += harpTuning[y];
                                continue;
                            }
                            else
                            {
                                // set i where the loop ended; if y indexs hit letter , we will set i index - 1 because you set loop i++;
                                i = y - 1 ;
                                break;
                            }
                        }
                    }
                    // if loop hit any letters start add temp_tune into listOfTune List and set temp_tune back to empty, waiting for next numric element. 
                    listOfTune.Add(temp_tune);
                    temp_tune = "";
                }
            }
         
            // format the output
                for(int index = 0; index < listOfInstruction.Count; index++)
            {       // check listofTune each index contain "-" or "+" , I can customize output "loose" or "tighten" , using Substring to ignore opertator (- or +).    
                   if (listOfTune[index].Contains("-"))
                {
                    outputMessage += listOfInstruction[index] + " loosen " + listOfTune[index].Substring(1) + ". | " ;
                }
                else
                {
                    outputMessage += listOfInstruction[index] + " tighten " + listOfTune[index].Substring(1) + ". | ";
                }
            }
            return outputMessage;
            
        }
    }
}
