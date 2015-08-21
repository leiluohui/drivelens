﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management;
using DiskMagic.DetectionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DiskMagic.DetectionLibrary.Tests
{
    [TestClass()]
    public class UtilityTest
    {
        [TestMethod()]
        public void GetVolumeObjectFromDeviceIdTest()
        {
            ManagementObject mo = WmiUtility.GetVolumeObjectByDeviceId("C:");
            Assert.AreEqual("C:\\", (string)mo["Name"]);
        }

        [TestMethod()]
        public void GetDiskPartitionObjectByDeviceIdTest()
        {
            ManagementObject mo = WmiUtility.GetDiskPartitionObjectByDeviceId("C:");
            Assert.IsTrue((ulong)mo["Size"] > 0);
        }

        [TestMethod()]
        public void GetDiskDriveObjectByDiskPartitionTest()
        {
            ManagementObject mo = WmiUtility.GetDiskDriveObjectByPartitionId((string)WmiUtility.GetFirstObjectOrNull("SELECT * FROM Win32_DiskPartition")["DeviceId"]);
            Assert.IsTrue((ulong)mo["Size"] > 0);
        }
    }
}