using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.PictureSearcher
{
    public struct SauceNaoItem
    {
        public float similarity; //相似度
        public string thumbnail;  //缩略图地址
        public string index_name;  //目录名(暂定用于识别图片在Pixiv中是否为多图id)

        public string title;  //作品标题
        public string pixiv_id;  //作品id
        public string member_name;  //作者名称
        public string member_id;  //作者id
        public List<string> ext_urls;  //作品地址

        public string creator;  //作者
        public string material;  //所属
        public string characters;  //角色
        public string source;  //图片来源
    }
}
