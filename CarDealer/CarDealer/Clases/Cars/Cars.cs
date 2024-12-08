namespace CarDealer
{
    
    namespace CarDealer
    {
        public class Cars : Vehicle
        {
            public int Mileage { get; set; }
            public int Year { get; set; }
            
            public Cars(string model, decimal price, int year, int mileage)
                : base(model, price)
            {
                Year = year;
                Mileage = mileage;
            }

            public Cars() 
            {
            }
            
            private const int minMileage = 0;
            private const int minPrice = 0;
            private const int minCarCreateYear = 1700;
            private const int maxCarCreateYear = 2024;
            
            public bool IsValid(out string validationMessage)
            {
                if (Mileage < minMileage)
                {
                    validationMessage = "Car mileage cannot be 0";
                    return false;
                }
                if (Price < minPrice)
                {
                    validationMessage = "Car price cannot be 0";
                    return false;
                }
                if (Year < minCarCreateYear || Year > maxCarCreateYear)
                {
                    validationMessage = $"The year of the car should be between {minCarCreateYear} and {maxCarCreateYear}";
                    return false;
                }

                validationMessage = string.Empty;
                return true;
            }

            public override string ToString()
            {
                return $"{Model} model - {Price:C} price - {Year} year - {Mileage} km mileage";
            }
        }
    }

}