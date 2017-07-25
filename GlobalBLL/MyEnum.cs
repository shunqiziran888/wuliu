using SuperCommand.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBLL
{
    /// <summary>
    /// 账号类型
    /// </summary>
    public enum AccountTypeEnum
    {
        物流账号 = 1,
        平台账号 = 2,
        普通用户账号 = 3,
        物流公司员工账号 =4
    }


    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStateEnum
    {
        审核中 = 0,
        正常 = 1,
        冻结 = 2,
        封号 = 3
    }

    public enum MessageEnum
    {
        [MsgState("成功")]
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,

        [MsgState("信息错误")]
        /// <summary>
        /// 信息错误
        /// </summary>
        MsgError = -2,

        [MsgState("数据库错误")]
        /// <summary>
        /// 数据库错误
        /// </summary>
        DBError = -3,

        [MsgState("其他数据错误")]
        /// <summary>
        /// 其他数据错误
        /// </summary>
        OtherError = -4,

        /// <summary>
        /// 未登录
        /// </summary>
        [MsgState("未登录")]
        Notlogin = -5,

        /// <summary>
        /// 已退出登录
        /// </summary>
        [MsgState("已退出登录")]
        UnLogin = -6,

        /// <summary>
        /// 商品名重复
        /// </summary>
        [MsgState("商品名重复")]
        ProductIsExits = -7,

        /// <summary>
        /// 没有权限访问
        /// </summary>
        [MsgState("没有权限访问")]
        NoPermissions = -8,

        /// <summary>
        /// 重新授权
        /// </summary>
        [MsgState("重新授权")]
        Reauthorization = -10,

        /// <summary>
        /// 没有任何数据
        /// </summary>
        [MsgState("没有任何数据")]
        NoData = -11
    }

    /// <summary>
    /// 登录枚举
    /// </summary>
    public enum LoginEnum
    {
        id,
        uid,
        /// <summary>
        /// 手机号
        /// </summary>
        phones,
        /// <summary>
        /// 用户名称
        /// </summary>
        username,
        /// <summary>
        /// 帐号
        /// </summary>
        account,
        /// <summary>
        /// 状态
        /// </summary>
        state,
        /// <summary>
        /// 职位ID
        /// </summary>
        positionID,
        /// <summary>
        /// 帐号类型
        /// </summary>
        accountType,
        /// <summary>
        /// 省ID
        /// </summary>
        ProvincesID,
        /// <summary>
        /// 市ID
        /// </summary>
        CityID,
        /// <summary>
        /// 区ID
        /// </summary>
        AreaID,
        /// <summary>
        /// 昵称
        /// </summary>
        NickName,
        OpenID,
        HeadPic,
        Sex,
        /// <summary>
        /// 省（微信）
        /// </summary>
        Province,
        /// <summary>
        /// 市（微信）
        /// </summary>
        City,
        /// <summary>
        /// 区（微信）
        /// </summary>
        Country,
        IsLogin,
    }



    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStateEnum
    {
        已发货=1,
        物流已收货 = 2,
        已装车运输中 = 3,
        已到收货地可提货 = 4,
        客户取货=5,
        订单完成=6,
        货物已中转=7
    }

    /// <summary>
    /// 提货方式
    /// </summary>
    public enum THFSEnum
    {
        客户自提=1,
        送货上门=2
    }
    /// <summary>
    /// 收货方式
    /// </summary>
    public enum SHFSENum
    {
        我方去送 = 1,
        物流来提 = 2
    }
    /// <summary>
    /// 运费方式
    /// </summary>
    public enum YFFSEnum
    {
        提付 = 1,
        现付 = 2,
        扣付 = 3
    }
    public enum PositionEnum
    {
        驾驶员 = 1,
        财务 = 2,
        业务 = 3,
        客服 = 4,
        管理员 = 5
    }
}
