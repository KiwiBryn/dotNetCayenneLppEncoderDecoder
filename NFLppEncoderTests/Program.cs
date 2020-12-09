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
// nanoff --target ST_STM32F429I_DISCOVERY --update
//
namespace devMobile.IoT.CayenneLpp.NFLppEncoderTests
{
   using System;
   using System.Diagnostics;

   using devMobile.IoT.CayenneLpp;

   public class Program
   {
      public static void Main()
      {
         Debug.WriteLine("Hello from nanoFramework!");

         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, 42.3519f, -87.9094f, 10.0f);

         string bcdText = encoder.Bcd();

         Debug.Assert(22==bcdText.Length );

         Debug.Assert("018806765FF2960A0003E8" == bcdText);
      }
   }
}
