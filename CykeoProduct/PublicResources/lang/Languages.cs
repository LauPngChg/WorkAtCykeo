namespace PublicResources.lang
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Languages
    {
        public static Uri ResourceEngUri { get => new Uri("/PublicResources;component/lang/en-us.xaml", UriKind.RelativeOrAbsolute); }
        public static Uri ResourceChsUri { get; } = new Uri("/PublicResources;component/lang/zh-cn.xaml", UriKind.RelativeOrAbsolute);
        
    }
}
