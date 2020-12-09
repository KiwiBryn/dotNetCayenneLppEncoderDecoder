//
// Copyright (c) November 2020, devMobile Software
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
namespace devMobile.IoT.CayenneLpp
{
   public static class Enumerations
   {
      public enum DataType : byte
      {
         DigitalInput = 0, // 1 byte
         DigitialOutput = 1, // 1 byte
         AnalogInput = 2, // 2 bytes, 0.01 signed
         AnalogOutput = 3, // 2 bytes, 0.01 signed
         Luminosity = 101, // 2 bytes, 1 lux unsigned
         Presence = 102, // 1 byte, 1
         Temperature = 103, // 2 bytes, 0.1°C signed
         RelativeHumidity = 104, // 1 byte, 0.5% unsigned
         Accelerometer = 113, // 2 bytes per axis, 0.001G
         BarometricPressure = 115, // 2 bytes 0.1 hPa Unsigned
         Gyrometer = 134, // 2 bytes per axis, 0.01 °/s
         Gps = 136, // 3 byte lon/lat 0.0001 °, 3 bytes alt 0.01m
      }
   }
}
