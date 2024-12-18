using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    /*
     * 在研究 DNA 时，识别 DNA 中的重复序列非常有用。
        给定一个表示 DNA序列 的字符串 s ，返回所有在 DNA 分子中出现不止一次的 长度为 10 的序列(子字符串)。
        你可以按 任意顺序 返回答案。

        示例 1：
        输入：s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
        输出：["AAAAACCCCC","CCCCCAAAAA"]
     * 
     */

    public class DnaSequenceSolution
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            IList<string> result = new List<string>();
            Dictionary<string, int> dic = new Dictionary<string, int>();

            int start = 0;
            int end = 10;

            while (start <= s.Length - end)
            {
                string seq = s.Substring(start, end);
                if (dic.ContainsKey(seq))
                {
                    dic[seq]++;
                }
                else
                {
                    dic[seq] = 1;
                }

                if (dic[seq] == 2)
                {
                    result.Add(seq);
                }

                start++;
            }

            return result;
        }

        public void Run()
        {
            string s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT";
            var result = FindRepeatedDnaSequences(s);
            foreach (string seq in result)
            {
                Console.WriteLine(seq);
            }
        }
    }
}
