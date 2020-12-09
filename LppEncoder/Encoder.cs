//
// Copyright (c) October 2020, devMobile Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Inspired by https://community.mydevices.com/t/cayenne-lpp-2-0/7510
//             https://developers.mydevices.com/cayenne/docs/lora/#lora-cayenne-low-power-payload
//    
// Some oddness with casting/conversion so library will work across .NetNF, TinyCLR and WildernessLabs Meadow.
//
namespace devMobile.IoT.CayenneLpp
{
   using System;
   using System.Text;

   public class Encoder
   {
      private readonly byte[] buffer;
      private byte index = 0;

      private void IsChannelNumberValid( byte channel)
      {
         if ((channel < Constants.ChannelMinimum) || (channel > Constants.ChannelMaximum))
         {
            throw new ArgumentException($"channel must be between {Constants.ChannelMinimum} and {Constants.ChannelMaximum}", "channel");
         }
      }

      private void IsBfferSizeSufficient(Enumerations.DataType dataType)
      {
         byte requiredSpace;

         switch (dataType)
         {
            case Enumerations.DataType.DigitalInput:
               requiredSpace = Constants.DigitalInputSize;
               break;
            case Enumerations.DataType.DigitialOutput:
               requiredSpace = Constants.DigitalOutputSize;
               break;
            case Enumerations.DataType.AnalogInput:
               requiredSpace = Constants.AnalogInputSize;
               break;
            case Enumerations.DataType.AnalogOutput:
               requiredSpace = Constants.AnalogOutputSize;
               break;
            case Enumerations.DataType.Luminosity:
               requiredSpace = Constants.LuminositySize;
               break;
            case Enumerations.DataType.Presence: 
               requiredSpace = Constants.PresenceSize;
               break;
            case Enumerations.DataType.Temperature:
               requiredSpace = Constants.TemperatureSize;
               break;
            case Enumerations.DataType.RelativeHumidity:
               requiredSpace = Constants.RelativeHumiditySize;
               break;
            case Enumerations.DataType.Accelerometer:
               requiredSpace = Constants.AccelerometerSize;
               break;
            case Enumerations.DataType.BarometricPressure:
               requiredSpace = Constants.AccelerometerSize;
               break;
            case Enumerations.DataType.Gyrometer:
               requiredSpace = Constants.GyrometerSize;
               break;
            case Enumerations.DataType.Gps:
               requiredSpace = Constants.GpsSize;
               break;
            default:
               throw new ArgumentException($"DataType {dataType} unknown", "dataType");
         };

         if ((index + requiredSpace) > buffer.Length)
         {
            throw new ApplicationException($"Datatype {dataType} insufficent buffer capacity");
         }
      }

      public Encoder(byte bufferSize)
      {
         if ((bufferSize < Constants.BufferSizeMinimum) || (bufferSize > Constants.BufferSizeMaximum))
         {
            throw new ArgumentException($"BufferSize must be between {Constants.BufferSizeMinimum} and {Constants.BufferSizeMaximum}", "bufferSize");
         }

         buffer = new byte[bufferSize];
      }

      public void Reset()
      {
         Array.Clear(buffer, 0, buffer.Length);
         index = 0;
      }

      public string Bcd()
      {
         StringBuilder payloadBcd = new StringBuilder(BitConverter.ToString(buffer, 0, index));

         payloadBcd = payloadBcd.Replace("-", "");

         return payloadBcd.ToString();
      }

      public void DigitalInputAdd(byte channel, bool value)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.DigitalInput);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.DigitalInput;

         // I know this is fugly but it works on all platforms
         if (value)
         {
            buffer[index++] = 1;
         }
         else
         {
            buffer[index++] = 0;
         }
      }

      public void DigitalOutputAdd(byte channel, bool value)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.DigitialOutput);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.DigitialOutput;

         // I know this is fugly but it works on all platforms
         if (value)
         {
            buffer[index++] = 1;
         }
         else
         {
            buffer[index++] = 0;
         }
      }

      public void AnalogInputAdd(byte channel, float value)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.AnalogOutput);

         short val = (short)(value * 100.0f);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.AnalogInput;
         buffer[index++] = (byte)(val >> 8);
         buffer[index++] = (byte)val;
      }

      public void AnalogOutputAdd(byte channel, float value)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.AnalogOutput);

         short val = (short)(value * 100.0f);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.AnalogOutput;
         buffer[index++] = (byte)(val >> 8);
         buffer[index++] = (byte)val;
      }

      public void LuminosityAdd(byte channel, ushort lux)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.Luminosity);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Luminosity;
         buffer[index++] = (byte)(lux >> 8);
         buffer[index++] = (byte)lux;
      }

      public void PresenceAdd(byte channel, bool value)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.Presence);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Presence;

         // I know this is fugly but it works on all platforms
         if (value)
         {
            buffer[index++] = 1;
         }
         else
         {
            buffer[index++] = 0;
         }
      }

      public void TemperatureAdd(byte channel, float celsius)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.Temperature);

         short val = (short)Math.Round(celsius * 10.0f);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Temperature;
         buffer[index++] = (byte)(val >> 8);
         buffer[index++] = (byte)val;
      }

      public void RelativeHumidityAdd(byte channel, float relativeHumidity)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.RelativeHumidity);

         byte val = (byte)(relativeHumidity * 2.0f);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.RelativeHumidity;
         buffer[index++] = val;
      }

      public void AccelerometerAdd(byte channel, float x, float y, float z)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.Accelerometer);

         short valX = (short)(x * 1000.0f);
         short valY = (short)(y * 1000.0f);
         short valZ = (short)(z * 1000.0f);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Accelerometer;
         buffer[index++] = (byte)(valX >> 8);
         buffer[index++] = (byte)(valX);
         buffer[index++] = (byte)(valY >> 8);
         buffer[index++] = (byte)(valY);
         buffer[index++] = (byte)(valZ >> 8);
         buffer[index++] = (byte)(valZ);
      }

      public void BarometricPressureAdd(byte channel, float hpa)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.BarometricPressure);

         short val = (short)(hpa * 10.0f);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.BarometricPressure;
         buffer[index++] = (byte)(val >> 8);
         buffer[index++] = (byte)val;
      }

      public void GyrometerAdd(byte channel, float x, float y, float z)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.Gyrometer);

         short valX = (short)(x * 100.0f);
         short valY = (short)(y * 100.0f);
         short valZ = (short)(z * 100.0f);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Gyrometer;
         buffer[index++] = (byte)(valX >> 8);
         buffer[index++] = (byte)valX;
         buffer[index++] = (byte)(valY >> 8);
         buffer[index++] = (byte)valY;
         buffer[index++] = (byte)(valZ >> 8);
         buffer[index++] = (byte)valZ;
      }

      public void GpsLocationAdd(byte channel, float latitude, float longitude, float meters)
      {
         IsChannelNumberValid(channel);
         IsBfferSizeSufficient(Enumerations.DataType.Gps);

         int lat = (int)(latitude * 10000.0f);
         int lon = (int)(longitude * 10000.0f);
         int alt = (int)(meters * 100);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Gps;

         buffer[index++] = (byte)(lat >> 16);
         buffer[index++] = (byte)(lat >> 8);
         buffer[index++] = (byte)lat;
         buffer[index++] = (byte)(lon >> 16);
         buffer[index++] = (byte)(lon >> 8);
         buffer[index++] = (byte)lon;
         buffer[index++] = (byte)(alt >> 16);
         buffer[index++] = (byte)(alt >> 8);
         buffer[index++] = (byte)alt;
      }
   }
}
