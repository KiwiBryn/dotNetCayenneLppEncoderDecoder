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
// The Cayenne Low Power Payload (LPP) provides a convenient and easy way to send data over LPWAN 
// networks such as LoRaWAN. The Cayenne LPP is compliant with the payload size restriction, which 
// can be lowered down to 11 bytes, and allows the device to send multiple sensor data at one time.
// Additionally, the Cayenne LPP allows the device to send different sensor data in different frames. 
// In order to do that, each sensor data must be prefixed with two bytes:

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

      private void IsBufferSizeSufficient(Enumerations.DataType dataType)
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
               requiredSpace = Constants.BarometricPressureSize;
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
            throw new ApplicationException($"Datatype {dataType} insufficent buffer capacity, maximum {buffer.Length} bytes");
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

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="value">boolean value, true or false</param>
      public void DigitalInputAdd(byte channel, bool value)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.DigitalInput);

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

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="value">boolean value, true or false</param>
      public void DigitalOutputAdd(byte channel, bool value)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.DigitialOutput);

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

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="value">Signed floating point value accourate to 0.01</param>
      public void AnalogInputAdd(byte channel, float value)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.AnalogInput);

         short val = (short)Math.Round(value * 100.0);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.AnalogInput;
         buffer[index++] = (byte)(val >> 8);
         buffer[index++] = (byte)val;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="value">Signed floating value accourate to 0.01</param>
      public void AnalogOutputAdd(byte channel, float value)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.AnalogOutput);

         short val = (short)Math.Round(value * 100.0);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.AnalogOutput;
         buffer[index++] = (byte)(val >> 8);
         buffer[index++] = (byte)val;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="value">Luminosity expressed in Lux</param>
      public void LuminosityAdd(byte channel, ushort value)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.Luminosity);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Luminosity;
         buffer[index++] = (byte)(value >> 8);
         buffer[index++] = (byte)value;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="value">boolean value indicating presence, true or false</param>
      public void PresenceAdd(byte channel, bool value)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.Presence);

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

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="value">Temperature in °C, accurate to 0.01°C</param>
      public void TemperatureAdd(byte channel, float value)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.Temperature);

         short val = (short)Math.Round(value * 10.0);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Temperature;
         buffer[index++] = (byte)(val >> 8);
         buffer[index++] = (byte)val;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="value">Relative hmidity in %, accurate to 0.5%</param>
      public void RelativeHumidityAdd(byte channel, float value)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.RelativeHumidity);

         byte val = (byte)Math.Round(value * 2.0);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.RelativeHumidity;
         buffer[index++] = val;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="x">X axis acceleration in G</param>
      /// <param name="y">Y axis acceleration in G</param>
      /// <param name="z">Z axis acceleration in G</param>
      public void AccelerometerAdd(byte channel, float x, float y, float z)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.Accelerometer);

         short valX = (short)Math.Round(x * 1000.0);
         short valY = (short)Math.Round(y * 1000.0);
         short valZ = (short)Math.Round(z * 1000.0);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Accelerometer;
         buffer[index++] = (byte)(valX >> 8);
         buffer[index++] = (byte)(valX);
         buffer[index++] = (byte)(valY >> 8);
         buffer[index++] = (byte)(valY);
         buffer[index++] = (byte)(valZ >> 8);
         buffer[index++] = (byte)(valZ);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="value">Barometric pressure in hectopascals(hPa), accurate to 0.01hPa</param>
      public void BarometricPressureAdd(byte channel, float value)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.BarometricPressure);

         short val = (short)Math.Round(value * 10.0);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.BarometricPressure;
         buffer[index++] = (byte)(val >> 8);
         buffer[index++] = (byte)val;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="x">X Axis rate expressed in °/sec, accurate to 0.01°/sec</param>
      /// <param name="y">X Axis rate expressed in °/sec, accurate to 0.01°/sec</param>
      /// <param name="z">X Axis rate expressed in °/sec, accurate to 0.01°/sec</param>
      public void GyrometerAdd(byte channel, float x, float y, float z)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.Gyrometer);

         short valX = (short)Math.Round(x * 100.0);
         short valY = (short)Math.Round(y * 100.0);
         short valZ = (short)Math.Round(z * 100.0);

         buffer[index++] = channel;
         buffer[index++] = (byte)Enumerations.DataType.Gyrometer;
         buffer[index++] = (byte)(valX >> 8);
         buffer[index++] = (byte)valX;
         buffer[index++] = (byte)(valY >> 8);
         buffer[index++] = (byte)valY;
         buffer[index++] = (byte)(valZ >> 8);
         buffer[index++] = (byte)valZ;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="channel">Uniquely identifies each sensor in the device across frames</param>
      /// <param name="latitude">Latitude in decimal degress, accurate to 0.0001°</param>
      /// <param name="longitude">Longitude in decimal degress, accurate to 0.0001°</param>
      /// <param name="altitude">Altitude in meters, accurate to 0.01M</param>
      public void GpsLocationAdd(byte channel, float latitude, float longitude, float altitude)
      {
         IsChannelNumberValid(channel);
         IsBufferSizeSufficient(Enumerations.DataType.Gps);

         if ((latitude < Constants.LatitudeMinimum ) || (latitude > Constants.LatitudeMaximum))
         {
            throw new ArgumentException($"Latitude must be between {Constants.LatitudeMinimum} and {Constants.LatitudeMaximum}", "latitude");
         }

         if ((longitude < Constants.LongitudeMinimum) || (longitude > Constants.LongitudeMaximum))
         {
            throw new ArgumentException($"Longitude must be between {Constants.LongitudeMinimum} and {Constants.LongitudeMaximum}", "longitude");
         }

         if ((altitude < Constants.AltitudeMinimum) || (altitude > Constants.AltitudeMaximum))
         {
            throw new ArgumentException($"Altitude must be between {Constants.AltitudeMinimum} and {Constants.AltitudeMaximum}", "altitude");
         }

         int lat = (int)Math.Round(latitude * 10000.0);
         int lon = (int)Math.Round(longitude * 10000.0);
         int alt = (int)Math.Round(altitude * 100.0);

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
