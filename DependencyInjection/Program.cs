using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DependencyInjection
{
    class Program //UI
    {
        static void Main(string[] args)
        {
            // UI Layer
            IUnityContainer objContainer = new UnityContainer();
            objContainer.RegisterType<Partner>();
            objContainer.RegisterType<Idal, SQLLayer>();
            objContainer.RegisterType<Idal, OracleLayer>();
            Partner myPartner = objContainer.Resolve<Partner>();

            //Partner my = objContainer.RegisterType<Idal, SQLLayer>("sql");

           // Partner myPartner = new Partner(new SQLLayer());
            myPartner.Add();
           
        }
    }

    public class Partner //Middle Layer
    {
        private Idal Odal;

        public Partner(Idal obj)
        {
            Odal = obj;  
        }

        public void Add()
        {
            // Invoke DAL
            //if (true)
            //{
            //    Odal = new SQLLayer();
                
            //}
            //else
            //{
            //    Odal = new OracleLayer();
               
            //}
            Odal.Add();  
        
        }
    
    }

    public interface Idal
    {
         void Add();
    }

    //DAL
    class SQLLayer : Idal
    {
        public void Add()
        {
            Console.WriteLine("In SQL");
        }
    
    }

    class OracleLayer : Idal
    {
        public void Add()
        {
            Console.WriteLine("In Ora");
        }
    }
}
