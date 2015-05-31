namespace MagicMouse.Sensor
{
    class SensorData
    {
        public double Ax { get; set; }
        public double Ay { get; set; }
        public double Az { get; set; }

        public double Gx { get; set; }
        public double Gy { get; set; }
        public double Gz { get; set; }


        public SensorData(byte[] pack)
        {
            Ax = load_mems(pack, 0);
            Ay = load_mems(pack, 1);
            Az = load_mems(pack, 2);

            Gx = load_mems(pack, 3);
            Gy = load_mems(pack, 4);
            Gz = load_mems(pack, 5);
        }

        private double load_mems(byte[] pack, int i)
        {
            byte MSB = pack[i * 2 + 4]; // вытаскиваем старшие и младшие биты
            byte LSB = pack[i * 2 + 3];
            short raw_data;
            if (i < 3) //данные для акселерометра
            {
                raw_data = (short)((short)(MSB << 4) | (short)(LSB >> 4)); //срединяем старший+младшии и отбрасываем  младшую тетраду
                if ((byte)(MSB & 0x80) == 0x80) //проверяем 12 бит = 1, если да то старшую. тетраду заполняем единицами
                {
                    raw_data |= Constants.one;
                }
                return raw_data * Constants.aksfactor; // переводим в G
            }
            else //данные для гироскопа
            {
                raw_data = (short)((short)(MSB << 8) | (short)LSB);
                return raw_data * Constants.girfactor;
            }
        }
    }
}