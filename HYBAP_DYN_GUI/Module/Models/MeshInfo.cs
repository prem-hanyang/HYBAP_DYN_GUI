using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Models
{
    [Serializable]
    public struct part_IEN_global
    {
        public int value1;
        public int value2;
        public int value3;
        public int value4;
    };

    [Serializable]
    public class MeshInfo
    {
        public MeshInfo()
        {
            SectionID = new List<int>();
            NodeCount = new List<int>();
            ElementCount = new List<int>();
            x_global = new List<List<double>>();
            z_global = new List<List<double>>();
            part_ID_global = new List<List<int>>();
            u0_global = new List<List<int>>();
            Gdiv_global = new List<List<int>>();
            Rdiv_global = new List<List<int>>();
            i_g_global = new List<List<int>>();
            H0_global = new List<List<int>>();
            part_IEN_global = new List<part_IEN_global[]>();
            RecirChannelNodeNumber = new List<int>();
            RecirChannelPart = new List<List<int>>();
            RecirChannelNode = new List<List<int>>();
        }

        #region Part

        // 0 차원
        public int PartCount
        {
            get;
            set;
        }

        // 1 차원 [PartCount + 1]
        public List<int> SectionID
        {
            get;
            set;
        }

        // 1 차원 [PartCount + 1]
        public List<int> NodeCount
        {
            get;
            set;
        }

        // 1 차원 [PartCount + 1]
        public List<int> ElementCount
        {
            get;
            set;
        }

        // 2 차원 [PartCount + 1] [NumOfNode[PartIndex] + 1]
        public List<List<double>> x_global
        {
            get;
            set;
        }

        // 2 차원 [PartCount + 1] [NumOfNode[PartIndex] + 1]
        public List<List<double>> z_global
        {
            get;
            set;
        }

        // 2 차원 [PartCount + 1] [NumOfNode[PartIndex] + 1]
        public List<List<int>> part_ID_global
        {
            get;
            set;
        }

        // 2 차원 [PartCount + 1] [NumOfNode[PartIndex] + 1]
        public List<List<int>> u0_global
        {
            get;
            set;
        }

        // 2 차원 [PartCount + 1] [20 + 1]
        public List<List<int>> Gdiv_global
        {
            get;
            set;
        }

        // 2 차원 [PartCount + 1] [20 + 1]
        public List<List<int>> Rdiv_global
        {
            get;
            set;
        }

        // 2 차원 [PartCount + 1] [NumOfElement[PartIndex] + 1]
        public List<List<int>> i_g_global
        {
            get;
            set;
        }

        // 2 차원 [PartCount + 1] [NumOfElement[PartIndex] + 1]
        public List<List<int>> H0_global
        {
            get;
            set;
        }

        // 3 차원 [PartCount + 1] [NumOfElement[PartIndex] + 1] [4 + 1]
        public List<part_IEN_global[]> part_IEN_global
        {
            get;
            set;
        }

        #endregion

        #region RecirChannel

        // 0 차원
        public int RecirChannelCount
        {
            get;
            set;
        }

        // 1 차원 [RecirChannelCount + 1]
        public List<int> RecirChannelNodeNumber
        {
            get;
            set;
        }

        // 2 차원 [RecirChannelCount + 1] [RecirChannelNodeNumber[RecirChannelIndex] + 1] 
        public List<List<int>> RecirChannelPart
        {
            get;
            set;
        }

        // 2 차원 [RecirChannelCount * 2 + 1] [RecirChannelNodeNumber[RecirChannelIndex] + 1] 
        public List<List<int>> RecirChannelNode
        {
            get;
            set;
        }

        #endregion
    }
}
