using System;

namespace Infruesture
{
    /// <summary>
    ///     微信收单成功消息推送数据实体
    /// </summary>
    public class WeChatOrdersPushReport
    {

        /// <summary>
        /// 当前用户微信的OpenId
        /// </summary>
        public string UserOpenId { get; set; }

        /// <summary>
        /// 是否关注子公众账号
        /// </summary>
        public int SubIsSubscribe { get; set; }

        /// <summary>
        ///     店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 顾客名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 性别（1-表示男，2-表示女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        ///     商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 是否是会员
        /// </summary>
        public bool IsMember { get; set; }

        /// <summary>
        ///     消费金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     当前余额（积分表示，采用微信模板，无法修改为当前积分，这里当前余额表示当前积分 ）
        /// </summary>
        public int? Balance { get; set; }

        /// <summary>
        ///     消费时间
        /// </summary>
        public DateTime PayDate { get; set; }

        /// <summary>
        /// 优惠券领取地址
        /// </summary>
        public string ShortUrl { get; set; }

        /// <summary>
        /// 设置默认优惠券的groupId
        /// </summary>
        public int WeixinPayDefaultCoupon { get; set; }
    }
}