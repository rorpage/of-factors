using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input)
        {
            int value = DateTime.Now.Year;
            if (!string.IsNullOrWhiteSpace(input))
            {
                dynamic jsonResponse = JsonConvert.DeserializeObject(input);
                if (jsonResponse.value != null)
                {
                    value = (int) jsonResponse.value;
                }
            }

            var output = new { factors = GetFactors(value) };
            Console.WriteLine(JsonConvert.SerializeObject(output));
        }

        private int[] GetFactors(int value)
        {
            return Enumerable.Range(1, value).Where(i => value % i == 0).ToArray();
        }
    }
}
