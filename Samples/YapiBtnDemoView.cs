using UnityEngine;

namespace YapiBtn.Samples
{
    public class YapiBtnDemoView : YapiBehavior
    {
        [YapiBtn]
        public void ShowYapiLog()
        {
            Debug.Log("Hello Yapi");
        }
    }
}