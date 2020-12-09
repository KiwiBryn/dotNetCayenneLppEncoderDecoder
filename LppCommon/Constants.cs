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
   public static class Constants
   {
      // This is limited by LoRa/LoRaWAN CR/BW configuration. Ranges from 51 to 222
      // see https://www.thethingsnetwork.org/forum/t/how-to-find-maximum-packet-size/25321/2
      public const byte BufferSizeMinimum = 3;
      public const byte BufferSizeMaximum = 222;

      public const byte ChannelMinimum = 0;
      public const byte ChannelMaximum = 64;

      public const byte DigitalInputSize = 3;
      public const byte DigitalOutputSize = 3;
      public const byte AnalogInputSize = 4;
      public const byte AnalogOutputSize = 4;
      public const byte LuminositySize = 4;
      public const byte PresenceSize = 3;
      public const byte TemperatureSize = 4;
      public const byte RelativeHumiditySize = 3;
      public const byte AccelerometerSize = 8;
      public const byte BarometricPressureSize = 4;
      public const byte GyrometerSize = 8;
      public const byte GpsSize = 11;

      public const float LatitudeMinimum = -90.0f;
      public const float LatitudeMaximum = 90.0f;
      public const float LongitudeMinimum = -180.0f;
      public const float LongitudeMaximum = 180.0f;

      public const float AltitudeMinimum = -100.0f;
      public const float AltitudeMaximum = 15000.0f;

   }
}
