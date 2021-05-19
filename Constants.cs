using PoultaryLatam.Resources;
using System.Collections.Generic;

namespace PoultaryLatam.Helpers
{
    public class Constants
    {
        public const string CustomerSupportNumber = "+50622981700";
        public static List<string> IncidentTypes = new List<string> { PoultaryResources.generalSupportRequest, PoultaryResources.updateYourInformation };

        #region Views
        public const string RootPage = "RootPageView";
        public const string LoginView = "LoginView";
        public const string LoadingImageView = "LoadingImageView";
        public const string DashboardView = "DashboardView";
        public const string ProductView = "ProductView";
        public const string ProductDetailsView = "ProductDetailView";
        public const string ShoppingCartView = "ShoppingCartView";
        public const string CheckoutView = "CheckoutView";
        public const string PlaceOrderView = "PlaceOrderView";
        public const string ViewAllView = "ViewAllView";
        public const string TryAgainView = "TryAgainView";
        public const string RegisterView = "RegistrationView";
        public const string ShippingAddressView = "EditShippingAddressView";
        public const string NoNetworkPopUpView = "NoNetworkPopUpView";
        public const string ServerErrorIssueView = "ServerErrorIssue";
        public const string ForgotPasswordView = "ForgotPasswordView";
        public const string ProductListView = "ProductListView";
        public const string AccountView = "AccountView";
        public const string SearchView = "SearchView";
        public const string BillingOrShippingAddressView = "BillingOrShippingAddressView";
        public const string ChangePasswordView = "ChangePasswordView";
        public const string CustomerServiceView = "CustomerServiceView";
        public const string OrderGuidlinessView = "OrderGuidlinessView";
        public const string OrderAcknowledgementView = "OrderAcknowledgementView";
        public const string SearchResultView = "SearchResultView";
        public const string MyOrdersView = "MyOrdersView";
        public const string OrderDetailView = "OrderDetailView";
        public const string UserSignupView = "UserSignupView";
        public const string TermsAndConditionsView = "TermsAndConditionsView";
        public const string FilteringView = "FilteringView";
        public const string FilterChildView = "FilterChildView";
        public const string NotificationsView = "NotificationsView";
        public const string NotificationHistoryView = "NotificationHistoryView";
        #endregion

        #region Configurations
        public const string TermsAndConditionsUrl = "https://www.cargill.com/page/privacy";
        
        ////Dev Environment
        public const string BaseURL = "https://api-dev.dev.dev-cglcloud.com";
        public const string DeploymentServerTypeForImage = "/dxpresources";
        public const string OrderingGuidelinesApi = "https://int.mycargill.com/poultry/{0}/{1}/api/ordering-guidelines";
        public const string CarouselApi = "https://int.mycargill.com/poultry/us/en/api/home-images";
        public const string ClientId = "0oai94jqwobznBXn70h7";
        public const string RedirectUri = "com.oktapreview.cargillcustomer-qa:/callback";
        public const string OrgUrl = "https://cargillcustomer-qa.oktapreview.com";
        public const string AuthorizationServerId = "auseru1y91KUkOCCB0h7";
        public const string ImageUrl = "https://s7test1.scene7.com/is/image";

        //Stage Environment
        //public const string BaseURL = "https://api-stage.stage.cglcloud.in";
        //public const string DeploymentServerTypeForImage = "/cargillincstage";
        //public const string OrderingGuidelinesApi = "https://stage.mycargill.com/poultry/{0}/{1}/api/ordering-guidelines";
        //public const string CarouselApi = "https://stage.mycargill.com/poultry/us/en/api/home-images";
        //public const string ClientId = "0oajg4rnuyNU834TA0h7";
        //public const string RedirectUri = "com.oktapreview.cargillcustomer-uat:/callback";
        //public const string OrgUrl = "https://cargillcustomer-uat.oktapreview.com";
        //public const string AuthorizationServerId = "ausf5swlrsgiHV3z70h7";
        //public const string ImageUrl = "https://s7d2.scene7.com/is/image";

        ////Production Environment
        //public const string BaseURL = "https://api.cglcloud.com";
        //public const string DeploymentServerTypeForImage = "/dxpresources";
        //public const string OrderingGuidelinesApi = "https://www.mycargill.com/poultry/{0}/{1}/api/ordering-guidelines";
        //public const string CarouselApi = "https://www.mycargill.com/poultry/us/en/api/home-images";
        //public const string ClientId = "0oa2m451w0N7qMtCW0i7";
        //public const string RedirectUri = "com.okta-emea.cargillcustomer:/callback";
        //public const string OrgUrl = "https://cargillcustomer.okta-emea.com";
        //public const string AuthorizationServerId = "aus1ykm8e9QxlFVM80i7";
        //public const string ImageUrl = "https://s7d2.scene7.com/is/image";

        #endregion

        #region API EndPoints

        public const string ProductApi = "/api/dxo/cps/v1/products/";
        public const string FeatureProductApi = "/api/dxo/cps/v1/search";
        public const string AllProductsApi = "/api/dxo/cps/v1/search";
        public const string AddToCartApi = "/api/dxo/cps/v1/cart/addItems";
        public const string CartCountApi = "/api/dxo/cps/v1/cart/fetch?itemCount=true";
        public const string ShippingOrBillingApi = "/api/dxo/cps/v1/users/current"; //"/api/dxo/cps/user-services/v1/users/current";
        public const string GetCartDetails = "/api/dxo/cps/v1/cart/fetch";
        public const string RemoveItemFromCartApi = "/api/dxo/cps/v1/cart/remove";
        public const string RemoveAllItemFromCartApi = "/api/dxo/cps/v1/cart/delete";
        public const string UpdateCartProductApi = "/api/dxo/cps/v1/cart/update";
        //public static string CarouselApi = "http://dev.fibi.cargill.com/poultry/en/api/home-images.model.json";
        public const string CustomerSupportApi = "/api/dxo/cps/utility-services/v1/email";
        public const string PlaceOrderApi = "/api/dxo/cps/v1/cart/placeOrder";
        public const string RelatedProducts = "/api/dxo/cps/v1/products/{0}/related";

        #endregion

        #region OktaConstants
        public const string AuthStateKey = "authState";
        public const string AuthServiceDiscoveryKey = "authServiceDiscovery";
        public static readonly string DiscoveryEndpoint =
            $"{OrgUrl}/oauth2/{AuthorizationServerId}/.well-known/openid-configuration";
        public static readonly string[] Scopes = new string[] {
        "openid", "profile", "email", "offline_access" };
        public static string AccessToken;
        public const string FromEmailAddress = "donotreply@cargill.com";
        public const string CustomerEmail_CCAddress = "";
        public const string csrEmailAddress = "Reclamos@cargill.com";//"pedidos@cargill.com";
        #endregion

        #region Other Charges
        public const int PageSizeCount_Search = 5;
        public const string EmailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        #endregion

        #region UI Settings by country and brand

        // Costa Rica - Pipasa
        public const string ToastMessageBackgroundColor = "#DF0000";
        public const string ToastMessageTextColor = "#FFFFFF";


        #endregion
    }
}
