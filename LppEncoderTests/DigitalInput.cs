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
   public class DigitalInput
   {
      [TestMethod]
      public void OnlyOneTrue()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalInputAdd(0, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(6, bcdText.Length);

         Assert.AreEqual("000001", bcdText);
      }


      [TestMethod]
      public void OnlyOneFalse()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalInputAdd(0, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(6, bcdText.Length);

         Assert.AreEqual("000000", bcdText);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooShortTwo()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalInputAdd(0, true);
         encoder.DigitalInputAdd(1, true);
      }

      [TestMethod]
      public void TwoTrue()
      {
         Encoder encoder = new Encoder(6);

         encoder.DigitalInputAdd(0, true);
         encoder.DigitalInputAdd(5, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(12, bcdText.Length);

         Assert.AreEqual("000001050001", bcdText);
      }

      [TestMethod]
      public void TwoTrueFalse()
      {
         Encoder encoder = new Encoder(6);

         encoder.DigitalInputAdd(0, true);
         encoder.DigitalInputAdd(1, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(12, bcdText.Length);

         Assert.AreEqual("000001010000", bcdText);
      }


      [TestMethod]
      public void TwoFalse()
      {
         Encoder encoder = new Encoder(6);

         encoder.DigitalInputAdd(0, false);
         encoder.DigitalInputAdd(1, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(12, bcdText.Length);

         Assert.AreEqual("000000010000", bcdText);
      }

      [TestMethod]
      public void TwoFalseTrue()
      {
         Encoder encoder = new Encoder(6);

         encoder.DigitalInputAdd(0, false);
         encoder.DigitalInputAdd(1, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(12, bcdText.Length);

         Assert.AreEqual("000000010001", bcdText);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooLong()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalInputAdd(0, true);
         encoder.DigitalInputAdd(1, true);
      }

      [TestMethod]
      public void BufferMaximum()
      {
         Encoder encoder = new Encoder(51);

         encoder.DigitalInputAdd(0, true);
         encoder.DigitalInputAdd(1, true);
         encoder.DigitalInputAdd(2, true);
         encoder.DigitalInputAdd(3, true);
         encoder.DigitalInputAdd(4, true);

         encoder.DigitalInputAdd(6, true);
         encoder.DigitalInputAdd(6, true);
         encoder.DigitalInputAdd(7, true);
         encoder.DigitalInputAdd(8, true);
         encoder.DigitalInputAdd(9, true);

         encoder.DigitalInputAdd(10, true);
         encoder.DigitalInputAdd(11, true);
         encoder.DigitalInputAdd(12, true);
         encoder.DigitalInputAdd(13, true);
         encoder.DigitalInputAdd(14, true);

         encoder.DigitalInputAdd(15, true);
         encoder.DigitalInputAdd(16, true);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMaximumTooLong()
      {
         Encoder encoder = new Encoder(51);

         encoder.DigitalInputAdd(0, true);
         encoder.DigitalInputAdd(1, true);
         encoder.DigitalInputAdd(2, true);
         encoder.DigitalInputAdd(3, true);
         encoder.DigitalInputAdd(4, true);

         encoder.DigitalInputAdd(6, true);
         encoder.DigitalInputAdd(6, true);
         encoder.DigitalInputAdd(7, true);
         encoder.DigitalInputAdd(8, true);
         encoder.DigitalInputAdd(9, true);

         encoder.DigitalInputAdd(10, true);
         encoder.DigitalInputAdd(11, true);
         encoder.DigitalInputAdd(12, true);
         encoder.DigitalInputAdd(13, true);
         encoder.DigitalInputAdd(14, true);

         encoder.DigitalInputAdd(15, true);
         encoder.DigitalInputAdd(16, true);
         encoder.DigitalInputAdd(17, true);
         encoder.DigitalInputAdd(18, true);
         encoder.DigitalInputAdd(19, true);

         encoder.DigitalInputAdd(20, true);
         encoder.DigitalInputAdd(21, true);
         encoder.DigitalInputAdd(22, true);
      }


      [TestMethod]
      public void ChannelMinimum()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalInputAdd(0, true);
      }

      [TestMethod]
      public void ChannelMaximum()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalInputAdd(64, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual("400001", bcdText);
      }

      [ExpectedException(typeof(ArgumentException))]
      [TestMethod]
      public void ChannelToLarge()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalInputAdd(65, true);
      }
   }
}
