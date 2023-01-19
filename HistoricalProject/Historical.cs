using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalProject
{
    public class Historical : IHistorical
    {
        private readonly string path = "DataBase.txt";
        public MyStreamWritter MyWritter { get; set; }

        public MyStreamReader MyReader { get; set; }

        public Historical() 
        {
            MyWritter = new MyStreamWritter();
            MyReader = new MyStreamReader();
        }


        public List<Data> GetDataById(int dataId) 
        {
            List<Data> searchedData = new List<Data>();
            try 
            {
                MyReader.Open(path);
                string line;
                while((line = MyReader.ReadLine()) != null) 
                {
                    string[] parts = line.Split('|');
                    int id = Convert.ToInt32(parts[0]);
                    double potrosnja = Convert.ToDouble(parts[1]);
                    if(id == dataId) 
                    {
                        Data d = new Data(id, potrosnja, parts[2], parts[3]);
                        searchedData.Add(d);
                    }

                }

                MyReader.Close();
                return searchedData;

            }
            catch(Exception e) 
            {
                return null;   
            }
        }


        public List<Data> GetDataByAdresa(string adresa)
        {
            List<Data> searchedData = new List<Data>();
            try
            {
                MyReader.Open(path);
                string line;
                while ((line = MyReader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    int id = Convert.ToInt32(parts[0]);
                    double potrosnja = Convert.ToDouble(parts[1]);
                    if (parts[2] == adresa)
                    {
                        Data d = new Data(id, potrosnja, parts[2], parts[3]);
                        searchedData.Add(d);
                    }

                }

                MyReader.Close();
                return searchedData;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Data> GetDataByMesec(string mesec)
        {
            List<Data> searchedData = new List<Data>();
            try
            {
                MyReader.Open(path);
                string line;
                while ((line = MyReader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    int id = Convert.ToInt32(parts[0]);
                    double potrosnja = Convert.ToDouble(parts[1]);
                    if (parts[3] == mesec)
                    {
                        Data d = new Data(id, potrosnja, parts[2], parts[3]);
                        searchedData.Add(d);
                    }

                }

                MyReader.Close();
                return searchedData;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Data> GetAllData()
        {
            List<Data> searchedData = new List<Data>();
            try
            {
                MyReader.Open(path);
                string line;
                while ((line = MyReader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    int id = Convert.ToInt32(parts[0]);
                    double potrosnja = Convert.ToDouble(parts[1]);
                   
                    Data d = new Data(id, potrosnja, parts[2], parts[3]);
                    searchedData.Add(d);
               
                }

                MyReader.Close();
                return searchedData;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool SaveData(List<Data> data)
        {
            try 
            {
                MyWritter.Open(path);
                foreach(Data d in data) 
                {
                    MyWritter.WriteLine(d.ToString());
                }
                MyWritter.Close();
                return true;
            
            }
            catch(Exception e) 
            {
                return false;
            }
        }
    }
}
