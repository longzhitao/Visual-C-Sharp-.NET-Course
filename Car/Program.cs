using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class Car
    {
        private readonly int oilConsumption = 10;
        //每一百公里消耗的油量
        private readonly int tankVolume = 100;
        //油箱容量
        private int oilGauge;
        //油表
        private int mileage;
        //里程数

        /// <summary>
        /// 生成一个新车，并且油箱加满
        /// </summary>
        public Car()
        {
            this.mileage = 0;
            this.oilGauge = this.tankVolume;
        }
        /// <summary>
        /// 生成一个新车，并且根据输入的加油量加油
        /// </summary>
        /// <param name="oilGauge">加油量</param>
        public Car(int oilGauge)
        {
            this.mileage = 0;
            this.oilGauge = oilGauge;
        }
        /// <summary>
        /// 生成一个旧车，记入里程数，根据输入加油量加油
        /// </summary>
        /// <param name="mileage">里程数</param>
        /// <param name="oilGauge">加油量</param>
        public Car(int mileage, int oilGauge)
        {
            this.mileage = mileage;
            this.oilGauge = oilGauge;
        }
        /// <summary>
        /// 计算驾驶后的油量
        /// </summary>
        /// <param name="mile">路程（英里）</param>
        /// <returns>驾驶后的油量</returns>
        private int CaculateOilConsumption(int mile)
        {
            return this.oilGauge - mile / 100 * this.oilConsumption;
        }
        /// <summary>
        /// 汽车根据输入路程行驶，并在控制台打印行驶是否成功
        /// </summary>
        /// <param name="mile">路程（英里）</param>
        public void Drive(int mile)
        {
            int oilGauge = this.CaculateOilConsumption(mile);
            if (oilGauge < 0)
                Console.WriteLine("Driving failure");
            else
            {
                this.oilGauge = oilGauge;
                this.mileage += mile;
                Console.WriteLine("Successful driving");
            }
        }
        /// <summary>
        /// 将油箱加满
        /// </summary>
        public void Refuel()
        {
            int fuel = this.tankVolume - this.oilGauge;
            this.oilGauge = this.tankVolume;
            Console.WriteLine("{0} liters of gas", fuel);
        }
        /// <summary>
        /// 根据加油量为汽车加油，并输出加油结果
        /// </summary>
        /// <param name="fuel">加油量</param>
        public void Refuel(int fuel)
        {
            int oilGauge = fuel + this.oilGauge;
            if (oilGauge > this.tankVolume)
                Console.WriteLine("Refuel failure");
            else
            {
                this.oilGauge = oilGauge;
                Console.WriteLine("Successful refueling");
            }
        }
        /// <summary>
        /// 打印汽车信息
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return "Oil Gauge: " + this.oilGauge + '\n' +
                "Mileage: " + this.Mileage;
        }
        public int OilConsumption => oilConsumption;

        public int TankVolume => tankVolume;
        public int OilGauge { get => oilGauge; set => oilGauge = value; }
        public int Mileage { get => mileage; set => mileage = value; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Drive(100);
            car.ShowInfo();
            car.Drive(400);
            car.ShowInfo();
            car.Refuel(60);
            car.ShowInfo();

            Console.Read();
        }
    }
}
