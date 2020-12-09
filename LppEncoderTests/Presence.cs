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
   public class Presence
   {
      [TestMethod]
      public void OnlyOneTrue()
      {
         Encoder encoder = new Encoder(3);

         encoder.PresenceAdd(0, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(6, bcdText.Length);

         Assert.AreEqual("006601", bcdText);
      }


      [TestMethod]
      public void OnlyOneFalse()
      {
         Encoder encoder = new Encoder(3);

         encoder.PresenceAdd(0, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(6, bcdText.Length);

         Assert.AreEqual("006600", bcdText);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooShortTwo()
      {
         Encoder encoder = new Encoder(3);

         encoder.PresenceAdd(0, true);
         encoder.PresenceAdd(1, true);
      }

      [TestMethod]
      public void TwoTrue()
      {
         Encoder encoder = new Encoder(6);

         encoder.PresenceAdd(0, true);
         encoder.PresenceAdd(5, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(12, bcdText.Length);

         Assert.AreEqual("006601056601", bcdText);
      }

      [TestMethod]
      public void TwoTrueFalse()
      {
         Encoder encoder = new Encoder(6);

         encoder.PresenceAdd(0, true);
         encoder.PresenceAdd(1, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(12, bcdText.Length);

         Assert.AreEqual("006601016600", bcdText);
      }


      [TestMethod]
      public void TwoFalse()
      {
         Encoder encoder = new Encoder(6);

         encoder.PresenceAdd(0, false);
         encoder.PresenceAdd(1, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(12, bcdText.Length);

         Assert.AreEqual("006600016600", bcdText);
      }

      [TestMethod]
      public void TwoFalseTrue()
      {
         Encoder encoder = new Encoder(6);

         encoder.PresenceAdd(0, false);
         encoder.PresenceAdd(1, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(12, bcdText.Length);

         Assert.AreEqual("006600016601", bcdText);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooLong()
      {
         Encoder encoder = new Encoder(3);

         encoder.PresenceAdd(0, true);
         encoder.PresenceAdd(1, true);
      }

      [TestMethod]
      public void BufferMaximum()
      {
         Encoder encoder = new Encoder(51);

         encoder.PresenceAdd(0, true);
         encoder.PresenceAdd(1, true);
         encoder.PresenceAdd(2, true);
         encoder.PresenceAdd(3, true);
         encoder.PresenceAdd(4, true);

         encoder.PresenceAdd(6, true);
         encoder.PresenceAdd(6, true);
         encoder.PresenceAdd(7, true);
         encoder.PresenceAdd(8, true);
         encoder.PresenceAdd(9, true);

         encoder.PresenceAdd(10, true);
         encoder.PresenceAdd(11, true);
         encoder.PresenceAdd(12, true);
         encoder.PresenceAdd(13, true);
         encoder.PresenceAdd(14, true);

         encoder.PresenceAdd(15, true);
         encoder.PresenceAdd(16, true);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMaximumTooLong()
      {
         Encoder encoder = new Encoder(51);

         encoder.PresenceAdd(0, true);
         encoder.PresenceAdd(1, true);
         encoder.PresenceAdd(2, true);
         encoder.PresenceAdd(3, true);
         encoder.PresenceAdd(4, true);

         encoder.PresenceAdd(6, true);
         encoder.PresenceAdd(6, true);
         encoder.PresenceAdd(7, true);
         encoder.PresenceAdd(8, true);
         encoder.PresenceAdd(9, true);

         encoder.PresenceAdd(10, true);
         encoder.PresenceAdd(11, true);
         encoder.PresenceAdd(12, true);
         encoder.PresenceAdd(13, true);
         encoder.PresenceAdd(14, true);

         encoder.PresenceAdd(15, true);
         encoder.PresenceAdd(16, true);
         encoder.PresenceAdd(17, true);
         encoder.PresenceAdd(18, true);
         encoder.PresenceAdd(19, true);

         encoder.PresenceAdd(20, true);
         encoder.PresenceAdd(21, true);
         encoder.PresenceAdd(22, true);
      }

      [TestMethod]
      public void ChannelMinimum()
      {
         Encoder encoder = new Encoder(3);

         encoder.PresenceAdd(0, true);
      }

      [TestMethod]
      public void ChannelMaximum()
      {
         Encoder encoder = new Encoder(3);

         encoder.PresenceAdd(64, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual("406601", bcdText);
      }

      [ExpectedException(typeof(ArgumentException))]
      [TestMethod]
      public void ChannelToLarge()
      {
         Encoder encoder = new Encoder(3);

         encoder.PresenceAdd(65, true);
      }
   }
}
