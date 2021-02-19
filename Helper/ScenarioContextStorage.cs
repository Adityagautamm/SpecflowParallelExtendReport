using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Helper
{
    class ScenarioContextStorage
    {

        public static Dictionary<string, Object> context;

        public static void createContext()
        {
            context = new Dictionary<string, object>();


        }
        public static void setContext(String aliasName, String value)
        {
            context.Add(aliasName, value);
        }

        public static String getContextInString(String aliasName)
        {
            object value;
            context.TryGetValue(aliasName, out value);
            return value.ToString();
        }

        public static void resetContext()
        {
            context.Clear();

        }

    }
}
