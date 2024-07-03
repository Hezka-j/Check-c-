namespace Check
{
    interface Product
    {
        string GetName();
        double GetCost();
        
    }

    struct Tomato : Product
    {
        double cost;
        string name;

        public Tomato()
        {
            cost = 25.6f;
            name = "tomato";
        }

        public string GetName() 
        { 
            return name;
        }

        public double GetCost() 
        {  
            return cost; 
        }
        
    }

    struct Cucumber : Product
    {
        double cost;
        string name;

        public Cucumber()
        {
            cost = 15.6f;
            name = "cucumber";
        }

        public string GetName()
        {
            return name;
        }

        public double GetCost()
        {
            return cost;
        }
    }

    struct Tax
    {
        int cost;

        public Tax() {
            cost = 0;
        }

        public int GetCost()
        {
            if(cost == 0)
            {
                Random rand = new Random();
                cost = rand.Next(0, 100);
            }
            return cost;
        }
    }

    struct Action
    {
        double action;
        
        public Action()
        {
            action = 0;
        }

        public double DoAction()
        {
            Random rand = new Random();
            if(rand.Next(0, 2) == 1)
            {
                action = rand.NextDouble();
            }
            if(action != 0)               
                return action;
            return 1;
        }
    }
    struct Check
    {
        string name;
        int number;
        DateTime date;
        List<Product> products;
        List<double> actionProducts;
        Action action;
        Tax tax;
        public Check() 
        {
            name = "Check";
            Random rand = new Random();
            number = rand.Next(100000, 100000000);
            date = DateTime.Now;
            products = new List<Product>();
            actionProducts = new List<double>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void Print()
        {
            Console.WriteLine("\t " + name);
            Console.WriteLine("\t" + number);
            Console.WriteLine(date);
            Console.WriteLine("Products:");
            for (int i = 0; i < products.Count; i++) 
            {
                Console.Write(products[i].GetName() + "\t\t\t\t");
                GetActionCost(products[i]);
                Console.WriteLine(actionProducts[i]);
                Console.WriteLine("Action: " + Math.Round(products[i].GetCost() - actionProducts[i], 2));
                Console.WriteLine("=========================================================");
            }
            Console.WriteLine("Tax: " + tax.GetCost());
            Console.WriteLine("Sum: " + Sum());
        }

        public void GetActionCost(in Product product)
        {
            actionProducts.Add(Math.Round(product.GetCost() * action.DoAction(), 2));
        }
        public double Sum()
        {
            double sum = 0;
            for(int i = 0; i < actionProducts.Count; i++)
            {
                sum += actionProducts[i];
            }
            sum += tax.GetCost();
            
            return sum;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Tomato a = new Tomato();
            Cucumber b = new Cucumber();
            Check c = new Check();
            c.AddProduct(a);
            c.AddProduct(b);
            c.Print();
        }
    }
}
