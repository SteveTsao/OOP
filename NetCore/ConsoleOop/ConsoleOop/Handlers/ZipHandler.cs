﻿using System.IO;
using System.IO.Compression;
using MyBackupCandidate;

namespace ConsoleOop.Handlers
{
    /// <summary>
    /// 壓縮處理
    /// </summary>
    class ZipHandler : AbstractHandler
    {
        /// <summary>
        /// 檔案壓縮
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案內容</param>
        /// <returns>壓縮後檔案內容</returns>
        public override byte[] PerForm(Candidate candidate, byte[] target)
        {
            byte[] bytes = null;

            using (var ms = new MemoryStream())
            {
                using (var zip = new GZipStream(ms, CompressionLevel.Optimal))
                {
                    zip.Write(target, 0, target.Length);
                }

                bytes = ms.ToArray();
            }

            return bytes;
        }
    }
}
