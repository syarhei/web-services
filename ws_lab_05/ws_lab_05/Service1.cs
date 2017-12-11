using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ws_lab_05 {
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1 {
        public string GetData(int value) {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int Add(int x, int y) {
            return x + y;
        }

        public string Concat(string s, double d) {
            return s + " " + d.ToString();
        }

        public MSU Sum(MSU msu1, MSU msu2) {
            return new MSU(msu1.s + msu2.s, msu1.k + msu2.k, msu1.f + msu2.f);
        }
    }
}
