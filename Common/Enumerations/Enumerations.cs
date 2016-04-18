namespace Common.Enumerations
{
    public enum IntegrationType
    {
        Opencart = 0,
        Magento,
        NopCommerce
    }

    public enum ExportType
    {
        Undefined = -1,
        Product = 0,
        Category = 1
    }

    public enum Status
    {
        Active,
        Passive,
        Suspended,
        Deleted
    }

    public enum Condition
    {
        Ok,
        Injured, // sakat
        Missing, //cezali
        Resting // dinlendiriliyor
    }

    public enum CatalogVersion
    {
        Demo,
        Standart,
        Professional
    }

    public enum TemplateType
    {
        Default,
        Food,
        WhiteAppliances // beyaz esya
    }

    public enum Key
    {
        Tag,
        Discount,
        Image,
        Video
    }

    public enum ResponseCode
    {
        Fail = 0,
        Success,
        Warning,
        Info,
        NoEffect
    }

    public enum WebMethodType
    {
        Null,
        Get,
        Post,
        Put,
        Info,
        NoEffect
    }

    public enum ContentType
    {
        Null,
        FormUrlencoded
    }

    public enum BettingType
    {
        All,
        Player
    }

    public enum BetSiteId
    {
        Rivalo = 1,
        TempoBet
    }
}