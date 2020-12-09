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
   using System;

   using Microsoft.VisualStudio.TestTools.UnitTesting;

   [TestClass]
   public class Acclerometer
   {
      [TestMethod]
      public void MyDevicesExampleOneAccelerometer()
      {
         Encoder encoder = new Encoder(51);

         encoder.AccelerometerAdd(6, 1.234f, -1.234f, 0.0f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(16, bcdText.Length);

         Assert.AreEqual("067104D2FB2E0000", bcdText);
      }
   }
}