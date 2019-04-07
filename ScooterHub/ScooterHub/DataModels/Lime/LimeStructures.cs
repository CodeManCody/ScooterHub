using System;
using System.Collections.Generic;

namespace ScooterHub.DataModels.Lime
{
    // Lime Auth API ===============================================================================

    public class LimeAuth
    {
        public string token { get; set; }
        public User user { get; set; }
        public Meta meta { get; set; }
        public string cookie { get; set; } // custom field
    }
    public class TotalDonationAmount
    {
        public string currency_code { get; set; }
        public double amount { get; set; }
        public string amount_str { get; set; }
        public string currency_symbol { get; set; }
        public string display_string { get; set; }
    }

    public class Attributes2
    {
        public string donation_type { get; set; }
        public List<object> donation_organizations { get; set; }
        public TotalDonationAmount total_donation_amount { get; set; }
        public object total_donation_amount_cents { get; set; }
        public object currency { get; set; }
    }

    public class DonationProfile
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes2 attributes { get; set; }
    }

    public class NewJuicerEarningsAmount
    {
        public string currency_code { get; set; }
        public double amount { get; set; }
        public string amount_str { get; set; }
        public string currency_symbol { get; set; }
        public string display_string { get; set; }
    }

    public class Balance
    {
        public string currency_code { get; set; }
        public double amount { get; set; }
        public string amount_str { get; set; }
        public string currency_symbol { get; set; }
        public string display_string { get; set; }
    }

    public class PendingBalance
    {
        public string currency_code { get; set; }
        public double amount { get; set; }
        public string amount_str { get; set; }
        public string currency_symbol { get; set; }
        public string display_string { get; set; }
    }

    public class Attributes
    {
        public string token { get; set; }
        public string phone_number { get; set; }
        public string email_address { get; set; }
        public bool has_verified_email_address { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string surname { get; set; }
        public object default_payment_method { get; set; }
        public string referral_code { get; set; }
        public int num_trips { get; set; }
        public bool edu { get; set; }
        public List<object> subscription_item_states { get; set; }
        public DonationProfile donation_profile { get; set; }
        public object juicer_profile_status { get; set; }
        public object juicer_profile_initial_activated_at { get; set; }
        public string pod_vehicle_banner_status { get; set; }
        public object juicer_referral_type { get; set; }
        public int accepted_user_agreement_version { get; set; }
        public NewJuicerEarningsAmount new_juicer_earnings_amount { get; set; }
        public object juicer_referral_amount { get; set; }
        public Balance balance { get; set; }
        public PendingBalance pending_balance { get; set; }
        public string new_juicer_earnings_promo_amount { get; set; }
        public int new_juicer_earnings_promo_amount_cents { get; set; }
        public int new_juicer_earnings_promo_amount_cent { get; set; }
        public string new_juicer_earnings_promo_currency { get; set; }
        public object juicer_referral_amount_cents { get; set; }
        public object juicer_referral_currency { get; set; }
        public int balance_cents { get; set; }
        public int pending_balance_cents { get; set; }
        public string currency { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Groups
    {
        public bool require_email_after_signup { get; set; }
    }

    public class Meta
    {
        public string latest_user_agreement_version { get; set; }
        public string min_ios_version { get; set; }
        public int min_android_code { get; set; }
        public string flags { get; set; }
        public Groups groups { get; set; }
    }

    // Main Lime API ===============================================================================


    public class LimeAPI
    {
        public Data data { get; set; }
        public Meta2 meta { get; set; }
    }

    public class TotalDonationAmount2
    {
        public string currency_code { get; set; }
        public double amount { get; set; }
        public string amount_str { get; set; }
        public string currency_symbol { get; set; }
        public string display_string { get; set; }
    }

    public class Attributes5
    {
        public string donation_type { get; set; }
        public List<object> donation_organizations { get; set; }
        public TotalDonationAmount2 total_donation_amount { get; set; }
        public object total_donation_amount_cents { get; set; }
        public object currency { get; set; }
    }

    public class DonationProfile2
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes5 attributes { get; set; }
    }

    public class NewJuicerEarningsAmount2
    {
        public string currency_code { get; set; }
        public double amount { get; set; }
        public string amount_str { get; set; }
        public string currency_symbol { get; set; }
        public string display_string { get; set; }
    }

    public class Balance2
    {
        public string currency_code { get; set; }
        public double amount { get; set; }
        public string amount_str { get; set; }
        public string currency_symbol { get; set; }
        public string display_string { get; set; }
    }

    public class PendingBalance2
    {
        public string currency_code { get; set; }
        public double amount { get; set; }
        public string amount_str { get; set; }
        public string currency_symbol { get; set; }
        public string display_string { get; set; }
    }

    public class Attributes4
    {
        public string token { get; set; }
        public string phone_number { get; set; }
        public string email_address { get; set; }
        public bool has_verified_email_address { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string surname { get; set; }
        public object default_payment_method { get; set; }
        public string referral_code { get; set; }
        public int num_trips { get; set; }
        public bool edu { get; set; }
        public List<object> subscription_item_states { get; set; }
        public DonationProfile2 donation_profile { get; set; }
        public object juicer_profile_status { get; set; }
        public object juicer_profile_initial_activated_at { get; set; }
        public string pod_vehicle_banner_status { get; set; }
        public object juicer_referral_type { get; set; }
        public int accepted_user_agreement_version { get; set; }
        public NewJuicerEarningsAmount2 new_juicer_earnings_amount { get; set; }
        public object juicer_referral_amount { get; set; }
        public Balance2 balance { get; set; }
        public PendingBalance2 pending_balance { get; set; }
        public string new_juicer_earnings_promo_amount { get; set; }
        public int new_juicer_earnings_promo_amount_cents { get; set; }
        public int new_juicer_earnings_promo_amount_cent { get; set; }
        public string new_juicer_earnings_promo_currency { get; set; }
        public object juicer_referral_amount_cents { get; set; }
        public object juicer_referral_currency { get; set; }
        public int balance_cents { get; set; }
        public int pending_balance_cents { get; set; }
        public string currency { get; set; }
    }

    public class User2
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes4 attributes { get; set; }
    }

    public class ZoneAttributes
    {
        public string name { get; set; }
        public string polyline { get; set; }
        public string category { get; set; }
    }

    public class Zone
    {
        public string id { get; set; }
        public string type { get; set; }
        public ZoneAttributes attributes { get; set; }
    }

    public class BikeAttributes
    {
        public string status { get; set; }
        public string plate_number { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public DateTime last_activity_at { get; set; }
        public object bike_icon { get; set; }
        public string type_name { get; set; }
        public string battery_level { get; set; }
        public int meter_range { get; set; }
        public string rate_plan { get; set; }
        public string rate_plan_short { get; set; }
        public int bike_icon_id { get; set; }
        public string last_three { get; set; }
        public object license_plate_number { get; set; }
    }

    public class Bike
    {
        public string id { get; set; }
        public string type { get; set; }
        public BikeAttributes attributes { get; set; }
    }

    public class IconAttributes
    {
        public string url { get; set; }
        public string description_icon_url { get; set; }
        public object description_link_url { get; set; }
        public string description { get; set; }
    }

    public class Icon
    {
        public string id { get; set; }
        public string type { get; set; }
        public IconAttributes attributes { get; set; }
    }

    public class Levels
    {
        public double region { get; set; }
        public double subregion { get; set; }
        public double city { get; set; }
    }

    public class BannerAttributes
    {
        public string text { get; set; }
        public string button_action { get; set; }
        public string button_text { get; set; }
        public string button_link { get; set; }
    }

    public class Banner
    {
        public string id { get; set; }
        public string type { get; set; }
        public BannerAttributes attributes { get; set; }
    }

    public class DataAttributes
    {
        public User2 user { get; set; }
        public object regions { get; set; }
        public List<Zone> zones { get; set; }
        public object bike_clusters { get; set; }
        public List<Bike> bikes { get; set; }
        public List<Icon> icons { get; set; }
        public string current_level { get; set; }
        public Levels levels { get; set; }
        public object most_recent_trip { get; set; }
        public Banner banner { get; set; }
        public object donation_organization { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string type { get; set; }
        public DataAttributes attributes { get; set; }
    }

    public class Payments
    {
        public bool cvv_optional { get; set; }
        public bool payment_creation_ui { get; set; }
        public bool payment_billing_address { get; set; }
        public bool payment_cardholder_name { get; set; }
        public bool payment_zip_code { get; set; }
        public bool payment_card_io_scan { get; set; }
    }

    public class Groups2
    {
        public bool show_auto_reload { get; set; }
        public bool map_levels_v1 { get; set; }
        public bool apple_pay { get; set; }
        public bool show_lock_indicator { get; set; }
        public bool force_location_permission_v1 { get; set; }
        public string unlock_button_group { get; set; }
        public string ring_button_group { get; set; }
        public string default_to_unlock_group { get; set; }
        public string take_photo { get; set; }
        public bool show_battery_level_on_map { get; set; }
        public bool unlock_confirmation { get; set; }
        public bool short_stop { get; set; }
        public bool bluetooth_unlock { get; set; }
        public bool lime_t_bluetooth_short_stop { get; set; }
        public bool juicer_earnings_notification { get; set; }
        public bool parked_or_not { get; set; }
        public bool branch_link_referral { get; set; }
        public bool persist_rate_ride { get; set; }
        public bool no_header_map { get; set; }
        public string donation_group { get; set; }
        public bool juicer_satellite_mode { get; set; }
        public bool juicer_level_2 { get; set; }
        public bool juicer_reservation_v1_ios { get; set; }
        public bool juicer_reservation_v1_android { get; set; }
        public bool enable_juicer_mock_gps_blocker { get; set; }
        public string id_scanner { get; set; }
        public bool new_method_completing_trip { get; set; }
        public bool juicer_bluetooth_unlock { get; set; }
        public bool cvv_optional { get; set; }
        public bool payment_creation_ui { get; set; }
        public bool payment_billing_address { get; set; }
        public bool payment_cardholder_name { get; set; }
        public bool payment_zip_code { get; set; }
        public Payments payments { get; set; }
        public bool lime_t_whitelisted { get; set; }
        public bool map_design_v3 { get; set; }
        public bool scooter_reservation { get; set; }
        public bool pod_reservation { get; set; }
        public bool use_moshi { get; set; }
        public bool android_how_to_ride_tutorial { get; set; }
        public bool enable_juicer_settings { get; set; }
        public bool enable_juicer_in_app_message { get; set; }
        public bool ios_juicer_multi_task_v1 { get; set; }
        public bool android_juicer_multi_task_v1 { get; set; }
    }

    public class Meta2
    {
        public string latest_user_agreement_version { get; set; }
        public string min_ios_version { get; set; }
        public int min_android_code { get; set; }
        public string flags { get; set; }
        public Groups2 groups { get; set; }
        public object trip_id { get; set; }
        public object trip_status { get; set; }
        public List<object> notifications { get; set; }
        public List<object> messages { get; set; }
        public string country_code { get; set; }
        public int user_agreement_version { get; set; }
        public string user_agreement_country_code { get; set; }
        public bool need_to_show_agreement { get; set; }
        public string user_agreement_url { get; set; }
    }
}
