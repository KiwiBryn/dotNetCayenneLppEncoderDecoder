//
// Copyright (c) December 2020, devMobile Software
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
   public class GPSLocation
   {
      [TestMethod]
      public void MyDevicesExampleOneGps()
      {
         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, 42.3519f, -87.9094f, 10.0f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(22, bcdText.Length);

         Assert.AreEqual("018806765FF2960A0003E8", bcdText);
      }

      [TestMethod]
      public void AcrossTheGreenwichMeridian()
      {
         Encoder encoder = new Encoder(121);

         encoder.GpsLocationAdd(5, 0.0f, 0.5f, 10.0f);
         encoder.GpsLocationAdd(4, 0.0f, 0.4f, 10.0f);
         encoder.GpsLocationAdd(3, 0.0f, 0.3F, 10.0f);
         encoder.GpsLocationAdd(2, 0.0f, 0.2f, 10.0f);
         encoder.GpsLocationAdd(1, 0.0f, 0.1f, 10.0f);

         encoder.GpsLocationAdd(0, 0.0f, 0.0f, 10.0f);

         encoder.GpsLocationAdd(1, 0.0f, -0.1f, 10.0f);
         encoder.GpsLocationAdd(2, 0.0f, -0.2f, 10.0f);
         encoder.GpsLocationAdd(3, 0.0f, -0.3f, 10.0f);
         encoder.GpsLocationAdd(4, 0.0f, -0.4f, 10.0f);
         encoder.GpsLocationAdd(5, 0.0f, -0.5f, 10.0f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(242, bcdText.Length);

         Assert.AreEqual("05880000000013880003E80488000000000FA00003E80388000000000BB80003E802880000000007D00003E801880000000003E80003E800880000000000000003E80188000000FFFC180003E80288000000FFF8300003E80388000000FFF4480003E80488000000FFF0600003E80588000000FFEC780003E8".Replace(" ",""), bcdText);
      }

      [TestMethod]
      public void AcrossTheEquator()
      {
         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, 42.3519f, -87.9094f, 10.0f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(22, bcdText.Length);

         Assert.AreEqual("018806765FF2960A0003E8", bcdText);
      }

      [TestMethod]
      public void AcrossTheAntipodalLine()
      {
         Encoder encoder = new Encoder(121);

         encoder.GpsLocationAdd(5, 0.0f, 0.5f, 10.0f);
         encoder.GpsLocationAdd(4, 0.0f, 0.4f, 10.0f);
         encoder.GpsLocationAdd(3, 0.0f, 0.3F, 10.0f);
         encoder.GpsLocationAdd(2, 0.0f, 0.2f, 10.0f);
         encoder.GpsLocationAdd(1, 0.0f, 0.1f, 10.0f);

         encoder.GpsLocationAdd(0, 0.0f, 0.0f, 10.0f);


         encoder.GpsLocationAdd(1, 0.0f, -0.1f, 10.0f);
         encoder.GpsLocationAdd(2, 0.0f, -0.2f, 10.0f);
         encoder.GpsLocationAdd(3, 0.0f, -0.3f, 10.0f);
         encoder.GpsLocationAdd(4, 0.0f, -0.4f, 10.0f);
         encoder.GpsLocationAdd(5, 0.0f, -0.5f, 10.0f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(242, bcdText.Length);

         Assert.AreEqual("05880000000013880003E8 0488000000000FA00003E8 0388000000000BB80003E8 02880000000007D00003E8 01880000000003E80003E8 00880000000000000003E8 0188000000FFFC180003E8 0288000000FFF8300003E8 0388000000FFF4480003E80488000000FFF0600003E80588000000FFEC780003E8".Replace(" ", "") , bcdText);
      }


      [TestMethod]
      public void LatitudeNotTooNegative()
      {
         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, -90.0f, 0.0f, 10.0f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(22, bcdText.Length);

         Assert.AreEqual("0188 F24460 000000 0003E8".Replace(" ",""), bcdText);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void LatitudeTooNegative()
      {
         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, -90.0001f, 0.0f, 10.0f);
      }

      [TestMethod]
      public void LatitudeNotTooPositive()
      {
         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, 90.0f, 0.00f, 10.0f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(22, bcdText.Length);

         Assert.AreEqual("0188 0DBBA0 000000 0003E8".Replace(" ",""), bcdText);
      }


      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void LatitudeTooPositive()
      {
         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, 90.0001f, 0.00f, 10.0f);
      }

      [TestMethod]
      public void LatitudeEquator()
      {
         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, 42.3519f, -87.9094f, 10.0f);
         /*
         string bcdText = encoder.Bcd();

         Assert.AreEqual(22, bcdText.Length);

         Assert.AreEqual("018806765FF2960A0003E8", bcdText);
         */
      }

      [TestMethod]
      public void LatitudeNorthPole()
      {
         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, 42.3519f, -87.9094f, 10.0f);
         /*
         string bcdText = encoder.Bcd();

         Assert.AreEqual(22, bcdText.Length);

         Assert.AreEqual("018806765FF2960A0003E8", bcdText);
         */
      }

      [TestMethod]
      public void LatitudeSouthPole()
      {
         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, 42.3519f, -87.9094f, 10.0f);
         /*
         string bcdText = encoder.Bcd();

         Assert.AreEqual(22, bcdText.Length);

         Assert.AreEqual("018806765FF2960A0003E8", bcdText);
         */
      }
   }
}