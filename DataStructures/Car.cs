using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    class Car
    {
        private string myName;
        public Car(string name)
        {
            this.myName = name;
        }

        public string Name
        {
            get { return this.myName; }
        }

    }
    
    class CarBroker
    {
        string vinNum;
        ServiceStation st = new ServiceStation();
        Car[] cars = new Car[] { new Car("ramu"), new Car("shamu"), new Car("reeta"), new Car("diya") };
        

        public string Name
        {
            get { return this.vinNum; }
        }

        private void PrintVin(string s)
        {
            Console.WriteLine(this.vinNum);
        }

        private void PrintNotif(string s)
        {
            Console.WriteLine(s);
        }

        public void SendForService(Car c)
        {
            st.OrderService(c, PrintVin);
        }

        public void StartServiceThread()
        {
            this.st.Run();

        }
    }

    class ServiceStation
    {
        public event PrintMessage ServiceCompleteNotify;

        Queue<Car> carQ = new Queue<Car>();
        internal void OrderService(Car c, PrintMessage printMsg)
        {
            printMsg("check vin");
            carQ.Enqueue(c);            
        }

        internal void StartService(Car c)
        {
            Console.WriteLine("In service");
            ServiceCompleteNotify(string.Format("your service done '{0}'", c.Name));
        }

        internal void Run()
        {
            while (true)
            {
                if (this.carQ.Count > 0)
                {
                    Car c = this.carQ.Dequeue();
                    if (c != null)
                    {
                        this.StartService(c);
                    }
                }
            }
        }
    }
}
