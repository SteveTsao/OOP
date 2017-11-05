﻿using System.IO;
using ConsoleOop.Configs;

namespace ConsoleOop.Handlers
{
    /// <summary>
    /// 檔案處理
    /// </summary>
    class FileHandler : AbstractHandler
    {
        /// <summary>
        /// 讀取、暫存檔案
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案</param>
        /// <returns>處理後檔案</returns>
        public override byte[] PerForm(Candidate candidate, byte[] target)
        {
            byte[] result = target;

            base.PerForm(candidate, target);

            if (target == null)
            {
                /// 轉換成 btyes
                return this.ConvertFileToByteArray(candidate);
            }

            /// 暫存檔案
            this.ConvertByteArrayToFile(candidate.Name + ".tmp", target);

            return result;
        }

        /// <summary>
        /// 讀取檔案轉換成btye型態
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <returns>檔案</returns>
        private byte[] ConvertFileToByteArray(Candidate candidate)
        {
            return File.ReadAllBytes(candidate.Config.Location + "\\" + candidate.Name);
        }
    }
}