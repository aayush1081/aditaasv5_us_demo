using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aditaas_v5.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "bot_master_menu_seq");

            migrationBuilder.CreateSequence(
                name: "bot_master_profile_seq");

            migrationBuilder.CreateSequence(
                name: "bot_message_details_seq");

            migrationBuilder.CreateSequence(
                name: "bot_message_seq");

            migrationBuilder.CreateSequence(
                name: "bot_profile_detail_seq");

            migrationBuilder.CreateSequence(
                name: "bot_system_configuration_seq");

            migrationBuilder.CreateSequence(
                name: "bot_system_reports_setting_seq");

            migrationBuilder.CreateSequence(
                name: "bot_user_details_seq");

            migrationBuilder.CreateSequence(
                name: "bot_user_login_seq");

            migrationBuilder.CreateSequence(
                name: "hibernate_sequence",
                incrementBy: 50);

            migrationBuilder.CreateSequence<int>(
                            name: "tbl_attachment_attachment_id_seq");

            migrationBuilder.CreateSequence(
                         name: "tbl_autodisc_trn_discovery_discovery_id_seq",
                         maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                            name: "tbl_cha_user_session_user_session_id_seq");

            migrationBuilder.CreateSequence(
                           name: "tbl_cmdb_attachment_attachment_id_seq");

            migrationBuilder.CreateSequence(
                           name: "tbl_cmdb_disc_mst_credential_credential_id_seq",
                           maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                          name: "tbl_cmdb_disc_mst_credential_type_credential_type_id_seq",
                          maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cmdb_disc_mst_discovery_discovery_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cmdb_disc_mst_discovery_schedule_schedule_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                           name: "tbl_dboard_dashboard_panel_details_uid_seq");

            migrationBuilder.CreateSequence(
                           name: "tbl_dboard_mst_visual_details_visual_details_id_seq");

            migrationBuilder.CreateSequence(
                            name: "tbl_mst_db_module_view_columns_db_view_column_id_seq");

            migrationBuilder.CreateSequence(
                           name: "tbl_mst_db_module_view_db_module_view_id_seq");

            migrationBuilder.CreateSequence(
                           name: "tbl_mst_module_cust_field_uid_seq",
                           maxValue: 2147483647L);

            migrationBuilder.CreateSequence<int>(
                           name: "tbl_mst_news_bulletin_bulletin_id_seq");

            migrationBuilder.CreateSequence(
                           name: "tbl_mst_wmi_ID_seq",
                           maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                           name: "tbl_rpt_report_schedule_uid_seq");

            migrationBuilder.CreateSequence<int>(
                name: "tbl_schedule_event_uid_seq");

            migrationBuilder.CreateSequence(
                          name: "tbl_survey_trn_ticket_survey_id_seq",
                          maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                          name: "tbl_trn_field_service_field_service_id1_seq",
                          maxValue: 2147483647L);

            migrationBuilder.CreateSequence<int>(
                           name: "tbl_trn_ticket_sla_ticket_sla_uid_seq");

            migrationBuilder.CreateSequence<int>(
                            name: "tbl_user_notification_uid_seq");

            migrationBuilder.CreateSequence(
                name: "tbl_cmdb_mst_software_software_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cmdb_trn_software_ci_map_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_autodisc_mac_info_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_autodisc_mst_discovery_ip_address_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_autodisc_mst_discovery_rule_action_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_autodisc_mst_discovery_rule_condition_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_autodisc_mst_discovery_rule_discovery_rule_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_autodisc_mst_mib_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_autodisc_trn_discovery_detail_uid_seq",
                maxValue: 2147483647L);









            migrationBuilder.CreateSequence(
                name: "tbl_cnf_config_item_mst_config_item_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_data_archive_archive_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_data_archive_cond_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_email_mgr_extract_field_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_priority_user_map_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_survey_cond_survey_cond_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_survey_ques_survey_ques_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_survey_survey_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_template_queue_template_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_template_tkt_approval_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_cnf_template_tkt_task_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_grid_state_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_action_menu_action_menu_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_activity_type_activity_type_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_cti_ent_mod_map_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_default_configuration_config_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_dept_entityattr_map_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_entityattr_org_map_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_flash_flash_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_ldapad_attr_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_ldapuser_attr_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_module_cust_field_role_mapper_uid_seq",
                maxValue: 2147483647L);



            migrationBuilder.CreateSequence(
                name: "tbl_mst_old_pwd_pid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_org_category_map_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_pwd_policy_pid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_role_action_right_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_survey_close_cond_survey_close_cond_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_survey_type_survey_type_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_mst_ticket_id_format_ticket_id_seq",
                maxValue: 2147483647L);



            migrationBuilder.CreateSequence(
                name: "tbl_mst_work_hr_queue_map_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_rpt_widget_user_option_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_survey_mst_form_question_detail_detail_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_survey_mst_form_question_question_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_survey_mst_form_survey_form_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_survey_trn_ticket_question_uid_seq",
                maxValue: 2147483647L);



            migrationBuilder.CreateSequence(
                name: "tbl_trn_activity_log_activity_log_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_archive_log_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_field_service_activity_log_activity_log_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_field_service_attachment_attachment_id_seq",
                maxValue: 2147483647L);



            migrationBuilder.CreateSequence(
                name: "tbl_trn_field_service_notes_log_notes_log_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_interaction_activity_log_activity_log_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_interaction_attachment_attachment_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_interaction_interaction_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_ldap_staging_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_problem_mpr_mpr_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_ticket_cust_field_detail_uid_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "tbl_trn_watch_list_watch_list_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "user_chat_message_seq");

            migrationBuilder.CreateSequence(
                name: "user_chat_message_user_chat_message_id_seq");

            migrationBuilder.CreateSequence(
                name: "user_chat_session_seq");

            migrationBuilder.CreateSequence(
                name: "user_chat_session_user_chat_session_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "user_details_seq");

            migrationBuilder.CreateSequence(
                name: "user_details_user_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "user_group_message_group_message_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "user_group_message_seq");

            migrationBuilder.CreateSequence(
                name: "user_groups_details_seq");

            migrationBuilder.CreateSequence(
                name: "user_groups_details_user_group_details_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "user_groups_group_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "user_groups_seq");

            migrationBuilder.CreateSequence(
                name: "user_online_seq");

            migrationBuilder.CreateSequence(
                name: "user_session_seq");

            migrationBuilder.CreateSequence(
                name: "user_session_user_session_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "visitor_chat_message_seq");

            migrationBuilder.CreateSequence(
                name: "visitor_chat_message_visitor_chat_message_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "visitor_chat_session_seq");

            migrationBuilder.CreateSequence(
                name: "visitor_chat_session_visitor_chat_session_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "visitor_details_seq");

            migrationBuilder.CreateSequence(
                name: "visitor_queue_seq");

            migrationBuilder.CreateSequence(
                name: "visitor_queue_visitor_queue_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateSequence(
                name: "visitor_session_seq");

            migrationBuilder.CreateSequence(
                name: "visitor_session_visitor_session_id_seq",
                maxValue: 2147483647L);

            migrationBuilder.CreateTable(
                name: "arch_cnf_follow_up",
                columns: table => new
                {
                    follow_up_id = table.Column<int>(type: "int", nullable: false),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    follow_up_type_id = table.Column<int>(type: "int", nullable: true),
                    user_define_user_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    set_by_id = table.Column<int>(type: "int", nullable: true),
                    set_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    asset_ci_type_id = table.Column<int>(type: "int", nullable: true),
                    sch_date_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    is_send_email = table.Column<bool>(type: "bit", nullable: true),
                    execution_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_cnf_follow_up_pkey", x => x.follow_up_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_appr_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_appr_attachment_pkey", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_approval",
                columns: table => new
                {
                    approval_id = table.Column<int>(type: "int", nullable: false),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appr_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appr_queue_id = table.Column<int>(type: "int", nullable: true),
                    approver_id = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    approved_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    actioned_on = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    type_ent_id = table.Column<int>(type: "int", nullable: true),
                    requester_id = table.Column<int>(type: "int", nullable: true),
                    authorized_by_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_from_workflow = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_approval_pkey", x => x.approval_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_inc_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_inc_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_inc_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_inc_attachment_pkey", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_inc_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_pk_inc_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_incident",
                columns: table => new
                {
                    incident_id = table.Column<int>(type: "int", nullable: false),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    contact_no = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    on_behalf_of_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    severity_ent_id = table.Column<int>(type: "int", nullable: true),
                    channel_ent_id = table.Column<int>(type: "int", nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    flags = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    nefcr_desc_ent_id = table.Column<int>(type: "int", nullable: true),
                    target_resolve_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    site_visit_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    alt_contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    white_board_no = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolved_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolved_by_id = table.Column<int>(type: "int", nullable: true),
                    short_desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    additional_comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    on_site_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    first_response_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fs_completed_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    escalation_ts_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    misroute_ts_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    email_response_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolution_method_ent_id = table.Column<int>(type: "int", nullable: true),
                    resolution_criteria_ent_id = table.Column<int>(type: "int", nullable: true),
                    caused_by_ent_id = table.Column<int>(type: "int", nullable: true),
                    tot_downtime_min = table.Column<int>(type: "int", nullable: true),
                    closed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_auto_closed = table.Column<bool>(type: "bit", nullable: true),
                    resolution_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    approval_type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    vendor_ticket_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    config_item_type = table.Column<int>(type: "int", nullable: true),
                    parent_incident_id = table.Column<int>(type: "int", nullable: true),
                    resolution_ci_id = table.Column<int>(type: "int", nullable: true),
                    config_item_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    config_item_db_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    config_ci_id = table.Column<int>(type: "int", nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    time_to_investigate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    time_to_diagnosis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sla_breach_reason = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    create_kb_flag = table.Column<bool>(type: "bit", nullable: true),
                    is_parent = table.Column<bool>(type: "bit", nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reopen_count = table.Column<int>(type: "int", nullable: true),
                    last_reopened_by_id = table.Column<int>(type: "int", nullable: true),
                    last_reopened_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    dateidentified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    comm_email = table.Column<bool>(type: "bit", nullable: true),
                    comm_call = table.Column<bool>(type: "bit", nullable: true),
                    comm_sms = table.Column<bool>(type: "bit", nullable: true),
                    last_pri_reason = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    last_pri_inspection = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    archive_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_incident_pkey", x => x.incident_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_pr_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_pr_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_pr_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_problem_attachment_pkey", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_pr_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_pk_pr_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_problem",
                columns: table => new
                {
                    problem_id = table.Column<int>(type: "int", nullable: false),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    short_desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    problem_description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    root_cause = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    symptom_code_ent_id = table.Column<int>(type: "int", nullable: true),
                    is_tested = table.Column<bool>(type: "bit", nullable: true),
                    knownerr_src_ent_id = table.Column<int>(type: "int", nullable: true),
                    knownerr_date_identified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    workaround = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_identified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closure_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    close_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closed_by_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    config_ci_id = table.Column<int>(type: "int", nullable: true),
                    impacted_ci_id = table.Column<int>(type: "int", nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    severity_ent_id = table.Column<int>(type: "int", nullable: true),
                    channel_ent_id = table.Column<int>(type: "int", nullable: true),
                    rca_date_identified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    vendor_ticket_id = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    alt_contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    create_kb_flag = table.Column<bool>(type: "bit", nullable: true),
                    resolution_method_ent_id = table.Column<int>(type: "int", nullable: true),
                    resolution_criteria_ent_id = table.Column<int>(type: "int", nullable: true),
                    caused_by_ent_id = table.Column<int>(type: "int", nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    comm_email = table.Column<bool>(type: "bit", nullable: true),
                    comm_call = table.Column<bool>(type: "bit", nullable: true),
                    comm_sms = table.Column<bool>(type: "bit", nullable: true),
                    last_pri_reason = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    last_pri_inspection = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    archive_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_problem_pkey", x => x.problem_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_task",
                columns: table => new
                {
                    task_id = table.Column<int>(type: "int", nullable: false),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    task_title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    due_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comments_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    closed_by_id = table.Column<int>(type: "int", nullable: true),
                    closed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    approval_id = table.Column<int>(type: "int", nullable: true),
                    is_from_workflow = table.Column<bool>(type: "bit", nullable: true),
                    archive_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_task_pkey", x => x.task_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_task_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_task_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_task_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_task_attachment_pk", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_task_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_pk_task_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "arch_trn_ticket_link",
                columns: table => new
                {
                    link_id = table.Column<int>(type: "int", nullable: false),
                    relation_type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    source_module_id = table.Column<int>(type: "int", nullable: true),
                    source_record_id = table.Column<int>(type: "int", nullable: true),
                    target_module_id = table.Column<int>(type: "int", nullable: true),
                    target_record_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("arch_trn_link_pkey", x => x.link_id);
                });

            migrationBuilder.CreateTable(
                name: "bot_master_menu",
                columns: table => new
                {
                    menu_code = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [bot_master_menu_seq])"),
                    menu_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    menu_link = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    menu_parent_id = table.Column<int>(type: "int", nullable: true),
                    menu_target = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    menu_image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    menu_alt_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    menu_placein_menu = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    menu_taborder = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    menu_isreleased = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')"),
                    menu_profile_access = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_master_menu_pkey", x => x.menu_code);
                });

            migrationBuilder.CreateTable(
                name: "bot_master_profile",
                columns: table => new
                {
                    profile_code = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [bot_master_profile_seq])"),
                    profile_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    is_active = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_master_profile_pkey", x => x.profile_code);
                });

            migrationBuilder.CreateTable(
                name: "bot_message",
                columns: table => new
                {
                    message_session_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [bot_message_seq])"),
                    message_bot_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    message_user_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    message_session_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_message_pkey", x => x.message_session_id);
                });

            migrationBuilder.CreateTable(
                name: "bot_message_details",
                columns: table => new
                {
                    message_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [bot_message_details_seq])"),
                    message_session_code = table.Column<int>(type: "int", nullable: true),
                    user_message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    bot_response = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    message_datetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_message_details_pkey", x => x.message_id);
                });

            migrationBuilder.CreateTable(
                name: "bot_profile_detail",
                columns: table => new
                {
                    profile_detail_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [bot_profile_detail_seq])"),
                    profile_code = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    menu_code = table.Column<int>(type: "int", nullable: true),
                    profile_insert_flag = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')"),
                    profile_update_flag = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')"),
                    profile_delete_flag = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')"),
                    profile_view_flag = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')"),
                    profile_general_flag = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_profile_detail_pkey", x => x.profile_detail_id);
                });

            migrationBuilder.CreateTable(
                name: "bot_system_configuration",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [bot_system_configuration_seq])"),
                    client_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    client_display_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    client_address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    client_contact1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    client_contact2 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    client_email1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    client_email2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    client_logo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    client_city = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    client_state = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    client_zipcode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    term_start_month = table.Column<int>(type: "int", nullable: true),
                    term_end_month = table.Column<int>(type: "int", nullable: true),
                    client_application = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    client_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    client_fb_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    client_twitter_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    client_linkedin_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    display_logo = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_system_configuration_pkey", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "bot_system_reports_setting",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [bot_system_reports_setting_seq])"),
                    report_client_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    report_client_name1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    report_client_name2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    report_client_name3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    report_client_name4 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    client_report_logo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    report_watermark_text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    report_watermark_logo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    report_footer_text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_system_reports_setting_pkey", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "bot_system_term",
                columns: table => new
                {
                    active_term = table.Column<int>(type: "int", nullable: false),
                    active_year = table.Column<int>(type: "int", nullable: true),
                    financial_year = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    is_active = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_system_term_pkey", x => x.active_term);
                });

            migrationBuilder.CreateTable(
                name: "bot_user_details",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [bot_user_details_seq])"),
                    user_title = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    user_fname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    user_mname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    user_lname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    user_dob = table.Column<DateTime>(type: "date", nullable: true),
                    user_gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    user_home_contact = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    user_mobile_contact = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    user_email_address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_active = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')"),
                    user_type = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    user_image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    user_std_code = table.Column<int>(type: "int", nullable: true),
                    user_employee_code = table.Column<int>(type: "int", nullable: true),
                    user_digital_signature = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    user_aadhar_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_user_details_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "bot_user_login",
                columns: table => new
                {
                    login_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [bot_user_login_seq])"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    user_login_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    user_login_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    enabled = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "('N')"),
                    account_non_expired = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    account_non_locked = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    credentials_not_expired = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    authentication_token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    token_expires = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    user_profile_id = table.Column<int>(type: "int", nullable: true),
                    user_theme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bot_user_login_pkey", x => x.login_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_cnf_wmi_command",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_mst_wmi_ID_seq])"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: true),
                    snmp_raw_value_type = table.Column<int>(type: "int", nullable: true),
                    delta_calculation = table.Column<int>(type: "int", nullable: true),
                    transformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    base_units = table.Column<int>(type: "int", nullable: true),
                    unit_multiplier = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_autodisc_cnf_wmi_command", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mac_info",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mac_prefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    manufacturer = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_autodisc_mac_info_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mst_credential",
                columns: table => new
                {
                    credential_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_cmdb_disc_mst_credential_credential_id_seq])"),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    protocol_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    password = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    snmp_auth_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    snmp_encryption_method = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    snmp_encryption_password = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    snmp_port = table.Column<int>(type: "int", nullable: true),
                    snmp_timeout = table.Column<int>(type: "int", nullable: true),
                    snmp_retry = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    snmp_community = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_disc_mst_credential_pk", x => x.credential_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mst_discovery",
                columns: table => new
                {
                    discovery_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_cmdb_disc_mst_discovery_discovery_id_seq])"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    site_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    credential_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_ignore_device = table.Column<bool>(type: "bit", nullable: true),
                    ignore_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ignore_ip_address_start = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ignore_ip_address_end = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ignore_ip_address_csv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ignore_condition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ignore_value_text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ip_address_csv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discovery_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    discovery_status = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_disc_mst_discovery_pk", x => x.discovery_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mst_discovery_rule",
                columns: table => new
                {
                    discovery_rule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_all_discovery = table.Column<bool>(type: "bit", nullable: true),
                    discovery_ids = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_autodisc_mst_discovery_rule_pk", x => x.discovery_rule_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mst_discovery_schedule",
                columns: table => new
                {
                    schedule_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_cmdb_disc_mst_discovery_schedule_schedule_id_seq])"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    monthly_selected_months = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    monthly_on_day = table.Column<int>(type: "int", nullable: true),
                    once_schedule_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    monthly_on_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    weekly_selected_days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weekly_on_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    daily_on_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    discovery_id = table.Column<int>(type: "int", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    schedule_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_disc_mst_discovery_schedule_pk", x => x.schedule_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mst_mib",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oid = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    manufacturer = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    oid_description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_autodisc_mst_mib", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mst_protocol",
                columns: table => new
                {
                    protocol_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_cmdb_disc_mst_credential_type_credential_type_id_seq])"),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_credential_req = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_disc_mst_credential_type_pk", x => x.protocol_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_trn_discovery",
                columns: table => new
                {
                    trn_discovery_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_autodisc_trn_discovery_discovery_id_seq])"),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    discovery_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_autodisc_trn_discovery_pk", x => x.trn_discovery_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_user_chat_message",
                columns: table => new
                {
                    user_chat_message_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [user_chat_message_user_chat_message_id_seq])"),
                    user_chat_message_session_code = table.Column<int>(type: "int", nullable: true),
                    user_sender_code = table.Column<int>(type: "int", nullable: true),
                    user_message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    user_message_timestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_message_delivery_type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    user_message_read_status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    user_target_code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_chat_message_pkey", x => x.user_chat_message_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_user_chat_session",
                columns: table => new
                {
                    user_chat_session_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [user_chat_session_user_chat_session_id_seq])"),
                    chat_session_code = table.Column<int>(type: "int", nullable: true),
                    chat_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    chat_session_user_code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_chat_session_pkey", x => x.user_chat_session_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_user_group_message",
                columns: table => new
                {
                    group_message_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [user_group_message_group_message_id_seq])"),
                    group_code = table.Column<int>(type: "int", nullable: true),
                    user_code = table.Column<int>(type: "int", nullable: true),
                    group_message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    group_message_timestamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_group_message_pkey", x => x.group_message_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_user_groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [user_groups_group_id_seq])"),
                    group_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    group_owner_code = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_groups_pkey", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_user_groups_details",
                columns: table => new
                {
                    user_group_details_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [user_groups_details_user_group_details_id_seq])"),
                    group_code = table.Column<int>(type: "int", nullable: true),
                    user_code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_groups_details_pkey", x => x.user_group_details_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_user_session",
                columns: table => new
                {
                    user_session_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [user_session_user_session_id_seq])"),
                    user_session_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_session_pkey", x => x.user_session_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_visitor_chat_message",
                columns: table => new
                {
                    visitor_chat_message_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [visitor_chat_message_visitor_chat_message_id_seq])"),
                    visitor_chat_message_session_code = table.Column<int>(type: "int", nullable: true),
                    visitor_sender_code = table.Column<int>(type: "int", nullable: true),
                    visitor_sender_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    visitor_sender_username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    visitor_message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    visitor_message_timestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    visitor_message_sender_type = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("visitor_chat_message_pkey", x => x.visitor_chat_message_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_visitor_chat_session",
                columns: table => new
                {
                    visitor_chat_session_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [visitor_chat_session_visitor_chat_session_id_seq])"),
                    visitor_session_code = table.Column<int>(type: "int", nullable: true),
                    visitor_session_user_code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    visitor_session_user_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    visitor_chat_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    visitor_session_user_type = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("visitor_chat_session_pkey", x => x.visitor_chat_session_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_visitor_queue",
                columns: table => new
                {
                    visitor_queue_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [visitor_queue_visitor_queue_id_seq])"),
                    visitor_user_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    visitor_bot_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    visitor_message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    visitor_user_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    visitor_session_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    visitor_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    visitor_attended = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('N')"),
                    visitor_online = table.Column<string>(type: "nvarchar(1)", nullable: true, defaultValueSql: "('Y')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("visitor_queue_pkey", x => x.visitor_queue_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cha_visitor_session",
                columns: table => new
                {
                    visitor_session_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [visitor_session_visitor_session_id_seq])"),
                    visitor_session_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("visitor_session_pkey", x => x.visitor_session_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_mst_ci_type",
                columns: table => new
                {
                    ci_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    ci_category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    image_src = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_mst_ci_type_pkey", x => x.ci_type_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_mst_ci_type_attr",
                columns: table => new
                {
                    ci_attr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ci_type_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    control_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    control_options = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_required = table.Column<bool>(type: "bit", nullable: true),
                    tooltips = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    max_length = table.Column<int>(type: "int", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    min_length = table.Column<int>(type: "int", nullable: true),
                    control_div_class = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    attr_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    property_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_mst_ci_type_attr_pkey", x => x.ci_attr_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_mst_software",
                columns: table => new
                {
                    software_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    brand_attr_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    additional_comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    license_count = table.Column<int>(type: "int", nullable: true),
                    product_key = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    license_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_mst_software_pkey", x => x.software_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_mst_vendor",
                columns: table => new
                {
                    vendor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    addr1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    addr2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    zip = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    contact_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    contact_phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_mst_vendor_pkey", x => x.vendor_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_ticket_link",
                columns: table => new
                {
                    ticket_link_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ci_id = table.Column<int>(type: "int", nullable: true),
                    ci_type_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_ticket_link_pkey", x => x.ticket_link_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_trn_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_trn_activity_log_pkey", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_trn_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_cmdb_attachment_attachment_id_seq])"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_attachment_pkey", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_trn_ci",
                columns: table => new
                {
                    ci_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ci_type_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    additional_comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    contact_no = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    alt_contact_no = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ci_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_trn_ci_pkey", x => x.ci_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_trn_ci_detail",
                columns: table => new
                {
                    ci_detail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ci_id = table.Column<int>(type: "int", nullable: true),
                    ci_attr_id = table.Column<int>(type: "int", nullable: true),
                    text_value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_value = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_trn_ci_detail_pkey", x => x.ci_detail_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_trn_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_trn_notes_log_pkey", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cmdb_trn_software_ci_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    software_id = table.Column<int>(type: "int", nullable: true),
                    ci_id = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cmdb_trn_software_ci_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_bus_field",
                columns: table => new
                {
                    bus_field_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    db_field_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    data_type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    field_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    entity_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_form_field_pkey", x => x.bus_field_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_catalog_cost",
                columns: table => new
                {
                    catalog_cost_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sr_template_id = table.Column<int>(type: "int", nullable: true),
                    allow_cost_details = table.Column<bool>(type: "bit", nullable: true),
                    service_cost = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_catalog_cost_pkey", x => x.catalog_cost_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_catalog_question",
                columns: table => new
                {
                    catalog_question_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    is_cost_enable = table.Column<bool>(type: "bit", nullable: true),
                    ans_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_catalog_question_pkey", x => x.catalog_question_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_config_item",
                columns: table => new
                {
                    config_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_config_item_pk", x => x.config_item_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_config_item_mst",
                columns: table => new
                {
                    config_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_config_item_mst_pk", x => x.config_item_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_data_archive",
                columns: table => new
                {
                    archive_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: false),
                    module_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    sql_cond = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    date_option = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    before_time_duration = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    archive_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    archive_from = table.Column<DateTime>(type: "datetime2", nullable: true),
                    archive_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    department_ids = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    location_ids = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_data_archive_pk", x => x.archive_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_email_template",
                columns: table => new
                {
                    email_template_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    to = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    cc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    bcc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    subject = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_html = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    template_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_email_template_pkey", x => x.email_template_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_follow_up",
                columns: table => new
                {
                    follow_up_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    follow_up_type_id = table.Column<int>(type: "int", nullable: true),
                    user_define_user_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    set_by_id = table.Column<int>(type: "int", nullable: true),
                    set_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    asset_ci_type_id = table.Column<int>(type: "int", nullable: true),
                    sch_date_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    is_send_email = table.Column<bool>(type: "bit", nullable: true),
                    execution_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_follow_up_pkey", x => x.follow_up_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_follow_up_type",
                columns: table => new
                {
                    follow_up_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_follow_up_type_pkey", x => x.follow_up_type_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_helpdesk_list",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    helpdesk_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_helpdesk_list_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_notify_rule_org_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notify_rule_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    email_template_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_notify_rule_org_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_priority_matrix",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    severity_id = table.Column<int>(type: "int", nullable: true),
                    impact_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    can_override = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_priority_matrix_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_priority_user_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_priority_user_map_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_sequence_override",
                columns: table => new
                {
                    override_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_sequence_override_pkey", x => x.override_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_template_change",
                columns: table => new
                {
                    template_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    template_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    cr_initiator_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    risk_ent_id = table.Column<int>(type: "int", nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    primary_ci = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    short_desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    change_description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    change_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    close_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    availability_ent_id = table.Column<int>(type: "int", nullable: true),
                    affects_public_facing = table.Column<bool>(type: "bit", nullable: true),
                    backup_available = table.Column<bool>(type: "bit", nullable: true),
                    users_impacted_ent_id = table.Column<int>(type: "int", nullable: true),
                    previously_executed_ent_id = table.Column<int>(type: "int", nullable: true),
                    backup_tested_ent_id = table.Column<bool>(type: "bit", nullable: true),
                    failover_available_ent_id = table.Column<int>(type: "int", nullable: true),
                    third_party_support_ent_id = table.Column<int>(type: "int", nullable: true),
                    backout_duration_ent_id = table.Column<int>(type: "int", nullable: true),
                    licensing_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    availability_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    cost_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    security_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    technical_impact = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    business_impact = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    business_risk = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    test_plan = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    backout_plan = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    planned_start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    planned_end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    actual_start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    actual_end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    physical_cab_req = table.Column<bool>(type: "bit", nullable: true),
                    physical_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closed_by_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    primary_ci_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    user_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    dept_id = table.Column<int>(type: "int", nullable: true),
                    is_work_flow = table.Column<bool>(type: "bit", nullable: true),
                    work_flow_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    is_reject_approval = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_template_change_pkey", x => x.template_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_template_incident",
                columns: table => new
                {
                    template_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    template_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    contact_no = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    on_behalf_of_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    severity_ent_id = table.Column<int>(type: "int", nullable: true),
                    channel_ent_id = table.Column<int>(type: "int", nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    config_item = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    flags = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    nefcr_desc_ent_id = table.Column<int>(type: "int", nullable: true),
                    target_resolve_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    site_visit_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    alt_contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    white_board_no = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolved_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolved_by_id = table.Column<int>(type: "int", nullable: true),
                    short_desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    additional_comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    on_site_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    first_response_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fs_completed_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    escalation_ts_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    misroute_ts_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    email_response_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolution_method_ent_id = table.Column<int>(type: "int", nullable: true),
                    resolution_criteria_ent_id = table.Column<int>(type: "int", nullable: true),
                    caused_by_ent_id = table.Column<int>(type: "int", nullable: true),
                    resolution_ci = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    tot_downtime_min = table.Column<int>(type: "int", nullable: true),
                    closed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_auto_closed = table.Column<bool>(type: "bit", nullable: true),
                    resolution_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    approval_type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    vendor_ticket_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    config_item_type = table.Column<int>(type: "int", nullable: true),
                    parent_incident_id = table.Column<int>(type: "int", nullable: true),
                    resolution_ci_type = table.Column<int>(type: "int", nullable: true),
                    resolution_ci_id = table.Column<int>(type: "int", nullable: true),
                    config_item_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    config_item_db_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    config_ci_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    user_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    create_kb_flag = table.Column<bool>(type: "bit", nullable: true),
                    sla_breach_reason = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_id = table.Column<int>(type: "int", nullable: true),
                    is_work_flow = table.Column<bool>(type: "bit", nullable: true),
                    work_flow_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    is_reject_approval = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_template_incident_pkey", x => x.template_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_template_problem",
                columns: table => new
                {
                    template_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    template_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    short_desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    config_item = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    problem_description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    root_cause = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    symptom_code_ent_id = table.Column<int>(type: "int", nullable: true),
                    is_tested = table.Column<bool>(type: "bit", nullable: true),
                    knownerr_src_ent_id = table.Column<int>(type: "int", nullable: true),
                    knownerr_date_identified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    workaround = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    impacted_ci = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    date_identified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closure_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    close_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closed_by_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    config_ci_id = table.Column<int>(type: "int", nullable: true),
                    impacted_ci_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    user_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    channel_ent_id = table.Column<int>(type: "int", nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    severity_ent_id = table.Column<int>(type: "int", nullable: true),
                    dept_id = table.Column<int>(type: "int", nullable: true),
                    is_work_flow = table.Column<bool>(type: "bit", nullable: true),
                    work_flow_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    is_reject_approval = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_template_problem_pkey", x => x.template_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_template_queue",
                columns: table => new
                {
                    template_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    template_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_template_queue_pkey", x => x.template_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_template_role_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_template_role_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_template_service_req",
                columns: table => new
                {
                    template_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    template_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    alt_contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    target_fulfill_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    severity_ent_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    config_item = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    channel_ent_id = table.Column<int>(type: "int", nullable: true),
                    on_behalf_of_id = table.Column<int>(type: "int", nullable: true),
                    site_visit_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    additional_comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fulfillment_method_ent_id = table.Column<int>(type: "int", nullable: true),
                    kb_ref_no = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    fulfillment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fulfilled_first_time = table.Column<bool>(type: "bit", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    close_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_auto_closed = table.Column<bool>(type: "bit", nullable: true),
                    fulfillment_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    vendor_ticket_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fulfilled_by_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    config_ci_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    user_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    sla_breach_reason = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_id = table.Column<int>(type: "int", nullable: true),
                    is_work_flow = table.Column<bool>(type: "bit", nullable: true),
                    work_flow_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    is_reject_approval = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_template_service_req_pkey", x => x.template_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_template_tkt_approval",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    appr_queue_id = table.Column<int>(type: "int", nullable: true),
                    approver_id = table.Column<int>(type: "int", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    linked_task = table.Column<bool>(type: "bit", nullable: true),
                    appr_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_template_tkt_approval_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_template_tkt_task",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    approval_template_id = table.Column<int>(type: "int", nullable: true),
                    task_title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_template_tkt_task_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_ticket_sch",
                columns: table => new
                {
                    ticket_sch_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scheule_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    schedule_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    start_from = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('true')"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    sch_detail = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_rule_scheduler_pkey", x => x.ticket_sch_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_ticket_trending",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    column_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_ticket_trending_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_tkt_num_format",
                columns: table => new
                {
                    ticket_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    id_format = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inc_num_length = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_ticket_id_format_pk", x => x.ticket_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dboard_dashboard",
                columns: table => new
                {
                    dashboard_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accessibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    access_user_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    dboard_module_id = table.Column<int>(type: "int", nullable: true),
                    auto_refresh_time = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_home_page = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('false')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_dboard_dashboard_pkey", x => x.dashboard_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dboard_dashboard_filter",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dashboard_id = table.Column<int>(type: "int", nullable: true),
                    view_column_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "nvarchar(max)", nullable: true),
                    operand1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    operand2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    in_bracket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    out_bracket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    and_or = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_operand_type1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_operand_type2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sub_operand1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sub_operand2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_dboard_dashboard_filter_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dboard_dashboard_panel",
                columns: table => new
                {
                    panel_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dashboard_id = table.Column<int>(type: "int", nullable: true),
                    visual_id = table.Column<int>(type: "int", nullable: true),
                    width = table.Column<int>(type: "int", nullable: true),
                    height = table.Column<int>(type: "int", nullable: true),
                    row = table.Column<int>(type: "int", nullable: true),
                    column = table.Column<int>(type: "int", nullable: true),
                    data_db_view_id = table.Column<int>(type: "int", nullable: true),
                    data_module_id = table.Column<int>(type: "int", nullable: true),
                    temp_panel_id = table.Column<int>(type: "int", nullable: true),
                    sql_query_data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ready_module_id = table.Column<int>(type: "int", nullable: true),
                    visual_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sql_query_drilldown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    top_n_record = table.Column<int>(type: "int", nullable: true),
                    is_ignore_dashboard_filter = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_dboard_dashboard_panel_pkey", x => x.panel_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dboard_dashboard_panel_color",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    panel_id = table.Column<int>(type: "int", nullable: true),
                    color_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_dboard_dashboard_panel_color_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dboard_dashboard_panel_detail",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_dboard_dashboard_panel_details_uid_seq])"),
                    panel_id = table.Column<int>(type: "int", nullable: true),
                    visual_detail_id = table.Column<int>(type: "int", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    summary_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    format_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    db_view_column_id = table.Column<int>(type: "int", nullable: true),
                    sort_order = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_dboard_dashboard_panel_details_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dboard_dashboard_panel_drilldown",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    panel_id = table.Column<int>(type: "int", nullable: true),
                    db_view_column_id = table.Column<int>(type: "int", nullable: true),
                    display_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    summary_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    format_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sort_order = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_dboard_dashboard_panel_drilldown_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dboard_dashboard_panel_filter",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    panel_id = table.Column<int>(type: "int", nullable: true),
                    db_view_column_id = table.Column<int>(type: "int", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "nvarchar(max)", nullable: true),
                    operand1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    operand2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    in_bracket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    out_bracket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    and_or = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_operand_type1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_operand_type2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sub_operand1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sub_operand2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_dboard_dashboard_panel_filter_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dboard_mst_visual",
                columns: table => new
                {
                    visual_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img_src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_color_option = table.Column<bool>(type: "bit", nullable: true),
                    options = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_dboard_mst_visual_pkey", x => x.visual_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dboard_mst_visual_detail",
                columns: table => new
                {
                    visual_detail_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_dboard_mst_visual_details_visual_details_id_seq])"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visual_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_multi_select = table.Column<bool>(type: "bit", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    summary_mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ctrl_height_px = table.Column<int>(type: "int", nullable: true),
                    is_required = table.Column<bool>(type: "bit", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_dboard_mst_visual_details_pkey", x => x.visual_detail_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_grid_state",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    grid_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    grid_state = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_grid_state_pk_uid", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_grid_state1",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    grid_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grid_state = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_action_menu",
                columns: table => new
                {
                    action_menu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    action_code = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    action_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    menu_id = table.Column<int>(type: "int", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_action_menu_pk", x => x.action_menu_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_activity_type",
                columns: table => new
                {
                    activity_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_activity_type_pk", x => x.activity_type_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_admin_module",
                columns: table => new
                {
                    admin_module_id = table.Column<int>(type: "int", nullable: false),
                    module_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_admin_module_pk", x => x.admin_module_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_attachment_attachment_id_seq])"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_attachment_pkey", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_bulletin",
                columns: table => new
                {
                    bulletin_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_mst_news_bulletin_bulletin_id_seq])"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    user_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attachment_id = table.Column<int>(type: "int", nullable: true),
                    web_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_news_bulletin_pkey", x => x.bulletin_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_city",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false),
                    city_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    state_id = table.Column<int>(type: "int", nullable: true),
                    cont_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_city_pkey", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_country",
                columns: table => new
                {
                    cont_id = table.Column<int>(type: "int", nullable: false),
                    cont_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_country_pkey", x => x.cont_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_cti_ent_mod_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    entity_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_cti_ent_mod_map_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_db_view",
                columns: table => new
                {
                    db_view_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_mst_db_module_view_db_module_view_id_seq])"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    db_view_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_dashboard = table.Column<bool>(type: "bit", nullable: true),
                    is_reporting = table.Column<bool>(type: "bit", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    org_db_col_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    queue_db_col_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_db_module_view_pkey", x => x.db_view_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_default_configuration",
                columns: table => new
                {
                    config_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    resolution_criteria_id = table.Column<int>(type: "int", nullable: true),
                    resolution_method_id = table.Column<int>(type: "int", nullable: true),
                    resolution_caused_by_id = table.Column<int>(type: "int", nullable: true),
                    resolution_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_default_configuration_pkey", x => x.config_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_dept_category_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dept_id = table.Column<int>(type: "int", nullable: true),
                    entity_attr_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_dept_entityattr_map_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_entity",
                columns: table => new
                {
                    entity_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    description = table.Column<string>(name: "description ", type: "nvarchar(400)", maxLength: 400, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_entity_pkey", x => x.entity_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_entity_module_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entity_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_entity_module_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_entityattr_org_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    entity_attr_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_entityattr_org_map_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_flash",
                columns: table => new
                {
                    flash_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flash_title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    flash_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_flash_pk", x => x.flash_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_holiday_grp",
                columns: table => new
                {
                    holiday_grp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    apply_to_org = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_holiday_grp_pkey", x => x.holiday_grp_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_holiday_grp_site_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    holiday_grp_id = table.Column<int>(type: "int", nullable: true),
                    site_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_holiday_grp_site_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_holiday_queue_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    holiday_grp_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_holiday_queue_map_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_language ",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    alias = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_language _pkey", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_ldapad_attr",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    property_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_ldapad_attr_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_ldapuser_attr",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    property_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_ldapuser_attr_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_menu",
                columns: table => new
                {
                    menu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    icon_tag = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    router_link = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    count_property = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('true')"),
                    parent_menu_id = table.Column<int>(type: "int", nullable: true),
                    is_dyn_submenu = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('false')"),
                    submenu_key = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    page_code = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_menu_pkey", x => x.menu_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_module_cust_field",
                columns: table => new
                {
                    field_uid = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_mst_module_cust_field_uid_seq])"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    field_code = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    control_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    is_required = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    control_div_class = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    option_json = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    is_base_field = table.Column<bool>(type: "bit", nullable: true),
                    default_value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    max_length = table.Column<int>(type: "int", nullable: true),
                    min_length = table.Column<int>(type: "int", nullable: true),
                    is_baseline_field = table.Column<bool>(type: "bit", nullable: true),
                    is_show_create_screen = table.Column<bool>(type: "bit", nullable: true),
                    is_show_edit_screen = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_module_cust_field_pk", x => x.field_uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_pwd_policy",
                columns: table => new
                {
                    pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_alpha_numeric = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    is_mixed_case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    pwd_expiry = table.Column<int>(type: "int", nullable: true),
                    check_previous_pwd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    previous_pwd = table.Column<int>(type: "int", nullable: true),
                    is_special_char = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    pwd_length = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_pwd_policy_pk", x => x.pid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_queue_module_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    queue_id = table.Column<int>(type: "int", nullable: false),
                    module_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_queue_module_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_role_action_right",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    action_id = table.Column<int>(type: "int", nullable: true),
                    menu_id = table.Column<int>(type: "int", nullable: true),
                    is_apply = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_role_action_right_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_state",
                columns: table => new
                {
                    state_id = table.Column<int>(type: "int", nullable: false),
                    state_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cont_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_state_pkey", x => x.state_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_timezone",
                columns: table => new
                {
                    timezone_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    utc_offset_min = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    utc_offset_display = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    country_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_timezone_pkey", x => x.timezone_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_user_dept_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_user_dept_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_user_pwd",
                columns: table => new
                {
                    pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    pwd_changed_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_old_pwd_pk", x => x.pid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_user_site_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    site_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_user_site_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_work_hr_queue_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    work_hr_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_work_hr_queue_map_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_report",
                columns: table => new
                {
                    report_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    widget_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    report_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accessibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    access_user_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    data_module_id = table.Column<int>(type: "int", nullable: true),
                    data_db_view_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sql_query_data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sql_query_drilldown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ready_module_id = table.Column<int>(type: "int", nullable: true),
                    top_n_record = table.Column<int>(type: "int", nullable: true),
                    is_hide = table.Column<bool>(type: "bit", nullable: true),
                    attachment_id = table.Column<int>(type: "int", nullable: true),
                    visual_id = table.Column<int>(type: "int", nullable: true),
                    summary_chart_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    advance_chart_visual_id = table.Column<int>(type: "int", nullable: true),
                    IsRuntimeRpt = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_report_pkey", x => x.report_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_report_color",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    report_id = table.Column<int>(type: "int", nullable: true),
                    color_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    color_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_report_color_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_report_detail",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    report_id = table.Column<int>(type: "int", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    summary_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    format_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    db_view_column_id = table.Column<int>(type: "int", nullable: true),
                    visual_detail_id = table.Column<int>(type: "int", nullable: true),
                    is_show_total = table.Column<bool>(type: "bit", nullable: true),
                    sort_order = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_report_detail_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_report_drilldown",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    report_id = table.Column<int>(type: "int", nullable: true),
                    db_view_column_id = table.Column<int>(type: "int", nullable: true),
                    display_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    summary_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    format_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sort_order = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_report_drilldown_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_report_filter",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    report_id = table.Column<int>(type: "int", nullable: true),
                    db_view_column_id = table.Column<int>(type: "int", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "nvarchar(max)", nullable: true),
                    operand1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    operand2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    in_bracket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    out_bracket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    and_or = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_operand_type1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_operand_type2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_runtime = table.Column<bool>(type: "bit", nullable: true),
                    sub_operand1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sub_operand2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_report_filter_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_report_scheduler",
                columns: table => new
                {
                    report_scheduler_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_rpt_report_schedule_uid_seq])"),
                    report_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    scheduler_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    monthly_selected_months = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    monthly_on_day = table.Column<int>(type: "int", nullable: true),
                    once_schedule_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    monthly_on_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    weekly_selected_days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weekly_on_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    daily_on_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    report_format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_to = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_cc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_executed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    next_execution_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_report_schedule_pkey", x => x.report_scheduler_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_schedule_export",
                columns: table => new
                {
                    export_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    report_id = table.Column<int>(type: "int", nullable: true),
                    export_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    mail_id = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    completed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    error_msg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_schedule_export_pk", x => x.export_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_widget",
                columns: table => new
                {
                    widget_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    is_public = table.Column<bool>(type: "bit", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_widget_pkey", x => x.widget_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_widget_report_hide",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    report_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    is_hide = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_widget_report_hide_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rpt_widget_user_option",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    widget_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_rpt_widget_user_option_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_schedule_event",
                columns: table => new
                {
                    schedule_event_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_schedule_event_uid_seq])"),
                    action_type = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    bus_rule_id = table.Column<int>(type: "int", nullable: true),
                    scheduled_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    additional_ref_id = table.Column<int>(type: "int", nullable: true),
                    event_type = table.Column<int>(type: "int", nullable: true),
                    counter = table.Column<int>(type: "int", nullable: true),
                    error_message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parent_schedule_event_id = table.Column<int>(type: "int", nullable: true),
                    executed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_schedule_event_pkey", x => x.schedule_event_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_appr_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_appr_attachment_pkey", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_archive_log",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    archive_id = table.Column<int>(type: "int", nullable: false),
                    started_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ended_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_archive_log_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_cr_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_cr_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_cr_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cr_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_field_service",
                columns: table => new
                {
                    field_service_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_trn_field_service_field_service_id1_seq])"),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    scheduled_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    additional_comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    start_time_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_time_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_number = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    closed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('true')"),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    punch_in_time_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    punch_out_time_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_change_reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_field_service_pk", x => x.field_service_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_field_service_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_field_service_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_field_service_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_field_service_attachment_pk", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_field_service_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_field_service_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_inc_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_inc_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_inc_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_inc_attachment_pkey", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_inc_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inc_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_interaction",
                columns: table => new
                {
                    interaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    severity_ent_id = table.Column<int>(type: "int", nullable: true),
                    channel_ent_id = table.Column<int>(type: "int", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    flags = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    nefcr_desc_ent_id = table.Column<int>(type: "int", nullable: true),
                    email_subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    email_body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    closed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closed_by_id = table.Column<int>(type: "int", nullable: true),
                    ticket_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    email_receipient = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_interaction_pkey", x => x.interaction_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_interaction_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_interaction_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_interaction_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_interaction_attachment_pkey", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_kb_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_kb_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_kb_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_kb_attachment_pk", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_kb_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kb_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_ldap_staging",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    samaccountname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    telephonenumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    site_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    company = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    useraccountcontrol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postal_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ip_phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    account_status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    is_modified = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_ldap_staging_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_login_activity",
                columns: table => new
                {
                    log_act_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_login_activity_pkey", x => x.log_act_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_pr_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_pr_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_pr_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pr_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_problem_mpr",
                columns: table => new
                {
                    mpr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problem_id = table.Column<int>(type: "int", nullable: true),
                    mpr_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mpr_date_next = table.Column<DateTime>(type: "datetime2", nullable: true),
                    problem_reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    incident_reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    attendees = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problem_manager = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    lessons_learnt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    incident_details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problem_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    initial_problem_severity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    final_problem_severity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    detection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actual_start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    frist_alarm_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    first_call_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    incident_open_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    problem_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    first_resolver = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    final_resolver = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    severity_1_escalation = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    diagnosis_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    restoration_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    recovery_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_customer_comm_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    management_comm_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    trigger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    root_cause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workaorund = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    failure_avoidance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    related_to_change_req = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    related_to_known_error = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    first_identified_by = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    how_issue_identified = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    owner_action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    owner_outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deu_date_action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    due_date_outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    act_item_json = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_problem_mpr_pk", x => x.mpr_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_sr_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_sr_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_sr_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_request_attachment_pk", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_sr_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sr_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_task_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_task_activity_log_pk", x => x.activity_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_task_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_task_attachment_pk", x => x.attachment_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_task_notes_log",
                columns: table => new
                {
                    notes_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    is_internal_notes = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_notes_log", x => x.notes_log_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_ticket_link",
                columns: table => new
                {
                    link_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    relation_type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    source_module_id = table.Column<int>(type: "int", nullable: true),
                    source_record_id = table.Column<int>(type: "int", nullable: true),
                    target_module_id = table.Column<int>(type: "int", nullable: true),
                    target_record_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_link_pkey", x => x.link_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_ticket_sla",
                columns: table => new
                {
                    record_id = table.Column<int>(type: "int", nullable: false),
                    module_id = table.Column<int>(type: "int", nullable: false),
                    sla_id = table.Column<int>(type: "int", nullable: true),
                    response_target_min = table.Column<int>(type: "int", nullable: true),
                    response_target_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    response_actual_min = table.Column<int>(type: "int", nullable: true),
                    response_stop_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolve_target_min = table.Column<int>(type: "int", nullable: true),
                    resolve_target_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolve_actual_min = table.Column<int>(type: "int", nullable: true),
                    resolve_stop_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    response_sla_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    resolve_sla_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    response_start_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolve_start_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ticket_sla_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_trn_ticket_sla_ticket_sla_uid_seq])"),
                    resolve_sla_percentage = table.Column<int>(type: "int", nullable: true),
                    resolve_sla_color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    response_sla_percentage = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true),
                    site_id = table.Column<int>(type: "int", nullable: true),
                    work_hr_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_ticket_sla_pkey", x => new { x.record_id, x.module_id });
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_ticket_spent_time",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    from_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    to_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    spent_min_total = table.Column<double>(type: "float", nullable: true),
                    spent_min_work = table.Column<double>(type: "float", nullable: true),
                    is_sla_pause = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('false')"),
                    last_calculated_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_calculated = table.Column<bool>(type: "bit", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_ticket_spent_time_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_ticket_survey",
                columns: table => new
                {
                    survey_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_survey_trn_ticket_survey_id_seq])"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    submitted_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    survey_guid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    survey_form_id = table.Column<int>(type: "int", nullable: true),
                    is_override = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('false')"),
                    submitted_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_survey_trn_ticket_pkey", x => x.survey_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_user_location",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    log_date_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_user_location_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_user_notification",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_user_notification_uid_seq])"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    message_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    message_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_unread = table.Column<bool>(type: "bit", nullable: true),
                    read_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    ticket_id = table.Column<int>(type: "int", nullable: true),
                    event_type = table.Column<int>(type: "int", nullable: true),
                    additional_ref_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_user_notification_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_watch_list",
                columns: table => new
                {
                    watch_list_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    mail_id = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_watch_list_pkey", x => x.watch_list_id);
                });

            migrationBuilder.CreateTable(
                name: "usermaster",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    site_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_vip = table.Column<bool>(type: "bit", nullable: true),
                    is_locked = table.Column<bool>(type: "bit", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    ad_username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "view_myfav_myapprovals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    idNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    module = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    queue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    approver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requester = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    orgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    moduleId = table.Column<int>(type: "int", nullable: true),
                    approverId = table.Column<int>(type: "int", nullable: true),
                    statusId = table.Column<int>(type: "int", nullable: true),
                    queueId = table.Column<int>(type: "int", nullable: true),
                    createdById = table.Column<int>(type: "int", nullable: true),
                    modifiedById = table.Column<int>(type: "int", nullable: true),
                    recordId = table.Column<int>(type: "int", nullable: true),
                    requesterId = table.Column<int>(type: "int", nullable: true),
                    orgId = table.Column<int>(type: "int", nullable: true),
                    is_vip = table.Column<bool>(type: "bit", nullable: true),
                    contactusername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactmobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactfirstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactlastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contacttitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactemail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactisactive = table.Column<bool>(type: "bit", nullable: true),
                    contactSiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rowNumberId = table.Column<int>(type: "int", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "www_view_dboard_incident_problem_linked_records",
                columns: table => new
                {
                    inc_id = table.Column<int>(type: "int", nullable: true),
                    inc_IdNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    inc_orgId = table.Column<int>(type: "int", nullable: true),
                    inc_currentQueueId = table.Column<int>(type: "int", nullable: true),
                    inc_shortDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    inc_orgName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inc_category = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_SubCategory = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_item = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_priority = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_contactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_assignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_lastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inc_resolvedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_resolvedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inc_closedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inc_queue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inc_status = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inc_altLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inc_channel = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_impact = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_severity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_moduleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_idNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    link_shortDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    link_openedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    link_category = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    link_subCategory = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    link_item = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    link_contactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_currQueue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    link_currStatus = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    link_orgName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    link_moduleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "www_view_dboard_problem_incident_link",
                columns: table => new
                {
                    orgid = table.Column<int>(type: "int", nullable: true),
                    currentqueueid = table.Column<int>(type: "int", nullable: true),
                    pr_idnumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    pr_shortdesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    pr_category = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    pr_subcategory = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    pr_item = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    pr_priority = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    pr_status = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    pr_assignedto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pr_contactname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pr_contactno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pr_location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pr_altlocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pr_openedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    pr_createdby = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pr_modifiedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    pr_modifiedby = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pr_queue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pr_orgname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pr_closedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pr_closedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    pr_vendorticketid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_idnumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    inc_shortdesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    inc_category = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_subcategory = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_item = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_priority = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_status = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_assignedto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_contactname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_contactno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inc_altlocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inc_openedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inc_createdby = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inc_modifiedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inc_modifiedby = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inc_queue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    inc_channel = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_resolvedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inc_resolvedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inc_closedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inc_resolutionmethod = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_resolutioncriteria = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_causedby = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_severity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    inc_vendorticketid = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mst_discovery_ip_address",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discovery_id = table.Column<int>(type: "int", nullable: true),
                    ip_address_start = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ip_address_end = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_autodisc_mst_discovery_ip_address_pk", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_autodisc_mst_discovery_ip_address_fk",
                        column: x => x.discovery_id,
                        principalTable: "tbl_autodisc_mst_discovery",
                        principalColumn: "discovery_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mst_discovery_rule_action",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discovery_rule_id = table.Column<int>(type: "int", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    action_value = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    notify_email_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notify_user_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notify_message_subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notify_message_body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_autodisc_mst_discovery_rule_action_pk", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_autodisc_mst_discovery_rule_action_fk",
                        column: x => x.discovery_rule_id,
                        principalTable: "tbl_autodisc_mst_discovery_rule",
                        principalColumn: "discovery_rule_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_mst_discovery_rule_condition",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discovery_rule_id = table.Column<int>(type: "int", nullable: true),
                    condition_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    condition_value = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_autodisc_mst_discovery_rule_condition_pk", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_autodisc_mst_discovery_rule_condition_fk",
                        column: x => x.discovery_rule_id,
                        principalTable: "tbl_autodisc_mst_discovery_rule",
                        principalColumn: "discovery_rule_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_autodisc_trn_discovery_detail",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trn_discovery_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    protocol_id = table.Column<int>(type: "int", nullable: true),
                    device_oid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mac_address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    manufacturer = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    device_type = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    host_name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    credential_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_autodisc_trn_discovery_detail_pk", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_autodisc_trn_discovery_detail_fk",
                        column: x => x.trn_discovery_id,
                        principalTable: "tbl_autodisc_trn_discovery",
                        principalColumn: "trn_discovery_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_catalog_question_dtls",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catalog_question_id = table.Column<int>(type: "int", nullable: true),
                    option_text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cost = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_catalog_question_dtls_pkey", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_cnf_catalog_question_dtls_fk_catalog_question_id",
                        column: x => x.catalog_question_id,
                        principalTable: "tbl_cnf_catalog_question",
                        principalColumn: "catalog_question_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_catalog_resource",
                columns: table => new
                {
                    catalog_resource_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sr_template_id = table.Column<int>(type: "int", nullable: true),
                    catalog_question_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_catalog_resource_pkey", x => x.catalog_resource_id);
                    table.ForeignKey(
                        name: "tbl_cnf_catalog_resource_fk_catalog_question_id",
                        column: x => x.catalog_question_id,
                        principalTable: "tbl_cnf_catalog_question",
                        principalColumn: "catalog_question_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_data_archive_cond",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    archive_id = table.Column<int>(type: "int", nullable: false),
                    form_field_id = table.Column<int>(type: "int", nullable: false),
                    @operator = table.Column<string>(name: "operator", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    match_values = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    and_or = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    start_brackets = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    end_brackets = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    archive_cond_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_data_archive_cond_pk", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_cnf_data_archive_cond_archive_id",
                        column: x => x.archive_id,
                        principalTable: "tbl_cnf_data_archive",
                        principalColumn: "archive_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_cnf_data_archive_cond_fk",
                        column: x => x.form_field_id,
                        principalTable: "tbl_cnf_bus_field",
                        principalColumn: "bus_field_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_admin_activity_log",
                columns: table => new
                {
                    activity_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    log_title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    fields_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    performed_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_activity_log_pkey", x => x.activity_log_id);
                    table.ForeignKey(
                        name: "tbl_mst_admin_activity_log_fk",
                        column: x => x.module_id,
                        principalTable: "tbl_mst_admin_module",
                        principalColumn: "admin_module_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_survey_mst_form",
                columns: table => new
                {
                    survey_form_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    department_ids = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    attachment_id = table.Column<int>(type: "int", nullable: true),
                    header_description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    footer_description_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    required_question_count = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    on_every_nth_ticket = table.Column<int>(type: "int", nullable: true),
                    ticket_survey_counter = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_survey_mst_form_pkey", x => x.survey_form_id);
                    table.ForeignKey(
                        name: "FK_ATTACHMENT_ID",
                        column: x => x.attachment_id,
                        principalTable: "tbl_mst_attachment",
                        principalColumn: "attachment_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_db_view_column",
                columns: table => new
                {
                    db_view_column_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_mst_db_module_view_columns_db_view_column_id_seq])"),
                    db_column_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    data_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    db_view_id = table.Column<int>(type: "int", nullable: false),
                    is_hide = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('false')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_db_module_view_columns_pkey", x => x.db_view_column_id);
                    table.ForeignKey(
                        name: "tbl_mst_db_view_column_db_view_id_fkey",
                        column: x => x.db_view_id,
                        principalTable: "tbl_mst_db_view",
                        principalColumn: "db_view_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_entity_attr",
                columns: table => new
                {
                    entity_attr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entity_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    parent_entity_attr_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    main_parent_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_entity_list_pkey", x => x.entity_attr_id);
                    table.ForeignKey(
                        name: "tbl_mst_entity_list_fk_entity_id",
                        column: x => x.entity_id,
                        principalTable: "tbl_mst_entity",
                        principalColumn: "entity_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_module_cust_field_role_mapper",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    field_uid = table.Column<int>(type: "int", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    access_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_module_cust_field_role_mapper_pk", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_mst_module_cust_field_role_mapper_fk",
                        column: x => x.field_uid,
                        principalTable: "tbl_mst_module_cust_field",
                        principalColumn: "field_uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_ticket_cust_field_detail",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    field_uid = table.Column<int>(type: "int", nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("newtable_pk", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_trn_ticket_cust_field_detail_fk",
                        column: x => x.field_uid,
                        principalTable: "tbl_mst_module_cust_field",
                        principalColumn: "field_uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_ticket_survey_question",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [tbl_survey_trn_ticket_question_uid_seq])"),
                    survey_id = table.Column<int>(type: "int", nullable: true),
                    question_id = table.Column<int>(type: "int", nullable: true),
                    selection_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<decimal>(type: "numeric(20,2)", nullable: true),
                    value_text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_survey_trn_ticket_question_pkey", x => x.uid);
                    table.ForeignKey(
                        name: "FK_SURVEY_ID",
                        column: x => x.survey_id,
                        principalTable: "tbl_trn_ticket_survey",
                        principalColumn: "survey_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_catalog_resource_dtls",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catalog_resource_id = table.Column<int>(type: "int", nullable: true),
                    resource_value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_catalog_resource_dtls_pkey", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_cnf_catalog_resource_dtls_fk_catalog_resource_id",
                        column: x => x.catalog_resource_id,
                        principalTable: "tbl_cnf_catalog_resource",
                        principalColumn: "catalog_resource_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_survey_mst_form_question",
                columns: table => new
                {
                    question_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    survey_form_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    question_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_required = table.Column<bool>(type: "bit", nullable: true),
                    min_length = table.Column<int>(type: "int", nullable: true),
                    max_length = table.Column<int>(type: "int", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_survey_mst_form_question_pkey", x => x.question_id);
                    table.ForeignKey(
                        name: "FK_SURVEY_FORM_ID",
                        column: x => x.survey_form_id,
                        principalTable: "tbl_survey_mst_form",
                        principalColumn: "survey_form_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_cr_details",
                columns: table => new
                {
                    change_details_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    availability_ent_id = table.Column<int>(type: "int", nullable: true),
                    affects_public_facing = table.Column<bool>(type: "bit", nullable: true),
                    backup_available = table.Column<bool>(type: "bit", nullable: true),
                    users_impacted_ent_id = table.Column<int>(type: "int", nullable: true),
                    previously_executed_ent_id = table.Column<int>(type: "int", nullable: true),
                    backup_tested_ent_id = table.Column<int>(type: "int", nullable: true),
                    failover_available_ent_id = table.Column<int>(type: "int", nullable: true),
                    third_party_support_ent_id = table.Column<int>(type: "int", nullable: true),
                    backout_duration_ent_id = table.Column<int>(type: "int", nullable: true),
                    licensing_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    availability_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    cost_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    security_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    technical_impact = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    business_impact = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    business_risk = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    test_plan = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    backout_plan = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    planned_start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    planned_end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    actual_start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    actual_end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    physical_cab_req = table.Column<bool>(type: "bit", nullable: true),
                    physical_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_change_details_pkey", x => x.change_details_id);
                    table.ForeignKey(
                        name: "tbl_trn_change_details_fk_availability_ent_id",
                        column: x => x.availability_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_change_details_fk_backout_duration_ent_id",
                        column: x => x.backout_duration_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_change_details_fk_backup_tested_ent_id",
                        column: x => x.backup_tested_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_change_details_fk_failover_available_ent_id",
                        column: x => x.failover_available_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_change_details_fk_previously_executed_ent_id",
                        column: x => x.previously_executed_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_change_details_fk_third_party_support_ent_id",
                        column: x => x.third_party_support_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_change_details_fk_users_impacted_ent_id",
                        column: x => x.users_impacted_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_survey_mst_form_question_detail",
                columns: table => new
                {
                    detail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<int>(type: "int", nullable: true),
                    question_id = table.Column<int>(type: "int", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_survey_mst_form_question_detail_pkey", x => x.detail_id);
                    table.ForeignKey(
                        name: "FK_QUESTION_ID",
                        column: x => x.question_id,
                        principalTable: "tbl_survey_mst_form_question",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_ad_ldap_field_map",
                columns: table => new
                {
                    ad_field_map_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad_ldap_id = table.Column<int>(type: "int", nullable: true),
                    aditaas_field_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ad_field_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_ad_ldap_field_map_pkey", x => x.ad_field_map_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_ad_schedule",
                columns: table => new
                {
                    ad_schedule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad_ldap_id = table.Column<int>(type: "int", nullable: true),
                    schedule_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    interval_days = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_ad_schedule_pkey", x => x.ad_schedule_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_bus_rule_cond",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    form_field_id = table.Column<int>(type: "int", nullable: false),
                    @operator = table.Column<string>(name: "operator", type: "nvarchar(150)", maxLength: 150, nullable: true),
                    match_values = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    and_or = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    start_brackets = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    end_brackets = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    bus_rule_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_bus_rule_cond_pkey", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_cnf_rule_cond_fk_form_field_id",
                        column: x => x.form_field_id,
                        principalTable: "tbl_cnf_bus_field",
                        principalColumn: "bus_field_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_datadrive_visborad",
                columns: table => new
                {
                    datadrive_visborad_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    task_table_id = table.Column<int>(type: "int", nullable: true),
                    vertlane_form_field_id = table.Column<int>(type: "int", nullable: true),
                    swim_form_field_id = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_datadrive_visborad_pkey", x => x.datadrive_visborad_id);
                    table.ForeignKey(
                        name: "tbl_cnf_datadrive_visborad_fk_swim_form_field_id",
                        column: x => x.swim_form_field_id,
                        principalTable: "tbl_cnf_bus_field",
                        principalColumn: "bus_field_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_cnf_datadrive_visborad_fk_vertlane_form_field_id",
                        column: x => x.vertlane_form_field_id,
                        principalTable: "tbl_cnf_bus_field",
                        principalColumn: "bus_field_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_sla_cond",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    form_field_id = table.Column<int>(type: "int", nullable: false),
                    @operator = table.Column<string>(name: "operator", type: "nvarchar(150)", maxLength: 150, nullable: true),
                    match_values = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    and_or = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    start_brackets = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    end_brackets = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sla_id = table.Column<int>(type: "int", nullable: true),
                    sla_cond_type = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_sla_cond_pkey", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_sla_cond_fk_form_field",
                        column: x => x.form_field_id,
                        principalTable: "tbl_cnf_bus_field",
                        principalColumn: "bus_field_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_bus_rule_action",
                columns: table => new
                {
                    rule_action_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bus_rule_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    message_subject = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    message_body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notify_user_bus_field_ids = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    notify_exclude_user_bus_field_ids = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rest_api_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_field_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notify_group_ids = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    notify_user_ids = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    notify_external_email_ids = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_rule_action_pkey", x => x.rule_action_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_catalog_order",
                columns: table => new
                {
                    catalog_order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_request_id = table.Column<int>(type: "int", nullable: true),
                    catalog_resource_dtls_id = table.Column<int>(type: "int", nullable: true),
                    value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    cost = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_catalog_order_pkey", x => x.catalog_order_id);
                    table.ForeignKey(
                        name: "tbl_trn_catalog_order_fk_catalog_resource_dtls_id",
                        column: x => x.catalog_resource_dtls_id,
                        principalTable: "tbl_cnf_catalog_resource_dtls",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_email_mgr_extract_field",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email_mgr_id = table.Column<int>(type: "int", nullable: true),
                    start_with = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_with = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    form_field_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_email_mgr_extract_field_pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_email_mgr_rule",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email_mgr_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    and_or = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    value = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    end_brackets = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    start_brackets = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_email_mgr_rule_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_notify_rule",
                columns: table => new
                {
                    notify_rule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    is_send_mail = table.Column<bool>(type: "bit", nullable: true),
                    email_template_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_push_notification = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_notification_pkey", x => x.notify_rule_id);
                    table.ForeignKey(
                        name: "tbl_cnf_notification_fk_email_template_id",
                        column: x => x.email_template_id,
                        principalTable: "tbl_cnf_email_template",
                        principalColumn: "email_template_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_freefrm_visborad_lane",
                columns: table => new
                {
                    visborad_lane_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    freefrm_visborad_id = table.Column<int>(type: "int", nullable: true),
                    lane_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_freefrm_visborad_lane_pkey", x => x.visborad_lane_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_freefrm_visborad_card",
                columns: table => new
                {
                    freefrm_visborad_card_id = table.Column<int>(type: "int", nullable: false),
                    visborad_lane_id = table.Column<int>(type: "int", nullable: true),
                    card_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_freefrm_visborad_card_pkey", x => x.freefrm_visborad_card_id);
                    table.ForeignKey(
                        name: "tbl_trn_freefrm_visborad_card_fk_visborad_lane_id",
                        column: x => x.freefrm_visborad_card_id,
                        principalTable: "tbl_cnf_freefrm_visborad_lane",
                        principalColumn: "visborad_lane_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_freefrm_visborad_attach",
                columns: table => new
                {
                    freefrm_visborad_attach_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    freefrm_visborad_card_id = table.Column<int>(type: "int", nullable: true),
                    attachment_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    file_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_freefrm_visborad_attach_pkey", x => x.freefrm_visborad_attach_id);
                    table.ForeignKey(
                        name: "tbl_trn_freefrm_visborad_attach_fk_freefrm_visborad_card_id",
                        column: x => x.freefrm_visborad_card_id,
                        principalTable: "tbl_trn_freefrm_visborad_card",
                        principalColumn: "freefrm_visborad_card_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_freefrm_visborad_chklist",
                columns: table => new
                {
                    freefrm_visborad_chklist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    freefrm_visborad_card_id = table.Column<int>(type: "int", nullable: true),
                    chk_list_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    is_checked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_freefrm_visborad_chklist_pkey", x => x.freefrm_visborad_chklist_id);
                    table.ForeignKey(
                        name: "tbl_trn_freefrm_visborad_chklist_fk_freefrm_visborad_card_id",
                        column: x => x.freefrm_visborad_card_id,
                        principalTable: "tbl_trn_freefrm_visborad_card",
                        principalColumn: "freefrm_visborad_card_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_freefrm_visborad_label",
                columns: table => new
                {
                    freefrm_visborad_label_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    freefrm_visborad_card_id = table.Column<int>(type: "int", nullable: true),
                    label_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_freefrm_visborad_label_pkey", x => x.freefrm_visborad_label_id);
                    table.ForeignKey(
                        name: "tbl_trn_freefrm_visborad_label_fk_freefrm_visborad_card_id",
                        column: x => x.freefrm_visborad_card_id,
                        principalTable: "tbl_trn_freefrm_visborad_card",
                        principalColumn: "freefrm_visborad_card_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_freefrm_visborad_note",
                columns: table => new
                {
                    freefrm_visborad_note_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    freefrm_visborad_card_id = table.Column<int>(type: "int", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_freefrm_visborad_note_pkey", x => x.freefrm_visborad_note_id);
                    table.ForeignKey(
                        name: "tbl_trn_freefrm_visborad_note_fk_freefrm_visborad_card_id",
                        column: x => x.freefrm_visborad_card_id,
                        principalTable: "tbl_trn_freefrm_visborad_card",
                        principalColumn: "freefrm_visborad_card_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_sla_action",
                columns: table => new
                {
                    sla_action_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sla_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    message_subject = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    notify_group_ids = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    notify_user_ids = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    message_body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    breach_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sla_percentage = table.Column<int>(type: "int", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    update_field_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notify_user_bus_field_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notify_exclude_user_bus_field_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notify_external_email_ids = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_sla_action_pkey", x => x.sla_action_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_change",
                columns: table => new
                {
                    change_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    risk_ent_id = table.Column<int>(type: "int", nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    short_desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    change_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    change_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    close_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    availability_ent_id = table.Column<int>(type: "int", nullable: true),
                    affects_public_facing = table.Column<bool>(type: "bit", nullable: true),
                    backup_available = table.Column<bool>(type: "bit", nullable: true),
                    users_impacted_ent_id = table.Column<int>(type: "int", nullable: true),
                    previously_executed_ent_id = table.Column<int>(type: "int", nullable: true),
                    backup_tested_ent_id = table.Column<bool>(type: "bit", nullable: true),
                    failover_available_ent_id = table.Column<int>(type: "int", nullable: true),
                    third_party_support_ent_id = table.Column<int>(type: "int", nullable: true),
                    backout_duration_ent_id = table.Column<int>(type: "int", nullable: true),
                    licensing_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    availability_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    cost_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    security_implications = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    technical_impact = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    business_impact = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    business_risk = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    test_plan = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    backout_plan = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    planned_start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    planned_end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    actual_start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    actual_end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    physical_cab_req = table.Column<bool>(type: "bit", nullable: true),
                    physical_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closed_by_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    primary_ci_id = table.Column<int>(type: "int", nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closure_notes = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    is_arch_restore = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_change_pkey", x => x.change_id);
                    table.ForeignKey(
                        name: "tbl_trn_change_fk_risk_ent_id",
                        column: x => x.risk_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_cr_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_change_attachment_pkey", x => x.attachment_id);
                    table.ForeignKey(
                        name: "tbl_trn_change_attachment_fk_change_id",
                        column: x => x.record_id,
                        principalTable: "tbl_trn_change",
                        principalColumn: "change_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_incident",
                columns: table => new
                {
                    incident_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    contact_no = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    on_behalf_of_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    severity_ent_id = table.Column<int>(type: "int", nullable: true),
                    channel_ent_id = table.Column<int>(type: "int", nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    flags = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    nefcr_desc_ent_id = table.Column<int>(type: "int", nullable: true),
                    target_resolve_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    site_visit_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    alt_contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    white_board_no = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolved_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolved_by_id = table.Column<int>(type: "int", nullable: true),
                    short_desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    additional_comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    on_site_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    first_response_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fs_completed_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    escalation_ts_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    misroute_ts_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    email_response_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolution_method_ent_id = table.Column<int>(type: "int", nullable: true),
                    resolution_criteria_ent_id = table.Column<int>(type: "int", nullable: true),
                    caused_by_ent_id = table.Column<int>(type: "int", nullable: true),
                    tot_downtime_min = table.Column<int>(type: "int", nullable: true),
                    closed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_auto_closed = table.Column<bool>(type: "bit", nullable: true),
                    resolution_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    approval_type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    vendor_ticket_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    config_item_type = table.Column<int>(type: "int", nullable: true),
                    parent_incident_id = table.Column<int>(type: "int", nullable: true),
                    resolution_ci_id = table.Column<int>(type: "int", nullable: true),
                    config_item_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    config_item_db_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    config_ci_id = table.Column<int>(type: "int", nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    time_to_investigate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    time_to_diagnosis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sla_breach_reason = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    create_kb_flag = table.Column<bool>(type: "bit", nullable: true),
                    is_parent = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reopen_count = table.Column<int>(type: "int", nullable: true),
                    last_reopened_by_id = table.Column<int>(type: "int", nullable: true),
                    last_reopened_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    dateidentified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    comm_email = table.Column<bool>(type: "bit", nullable: true),
                    comm_call = table.Column<bool>(type: "bit", nullable: true),
                    comm_sms = table.Column<bool>(type: "bit", nullable: true),
                    last_pri_inspection = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    last_pri_reason = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    is_pr_link_discard = table.Column<bool>(type: "bit", nullable: true),
                    is_arch_restore = table.Column<bool>(type: "bit", nullable: true),
                    preferred_contact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_incident_pkey", x => x.incident_id);
                    table.ForeignKey(
                        name: "tbl_trn_incident_fk_caused_by_ent_id",
                        column: x => x.caused_by_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_incident_fk_channel_int_id",
                        column: x => x.channel_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_incident_fk_nefcr_desc_ent_id",
                        column: x => x.nefcr_desc_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_incident_fk_resolution_criteria_ent_id",
                        column: x => x.resolution_criteria_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_incident_fk_resolution_method_ent_id",
                        column: x => x.resolution_method_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_incident_fk_severity_ent_id",
                        column: x => x.severity_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_kb",
                columns: table => new
                {
                    kb_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    sub_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addl_link = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    article_image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    source_ent_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    config_item = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    kb_type_ent_id = table.Column<int>(type: "int", nullable: true),
                    avail_for = table.Column<int>(type: "int", nullable: true),
                    assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    tags = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    views_cnt = table.Column<int>(type: "int", nullable: true),
                    comment_cnt = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    ratings = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    config_ci_id = table.Column<int>(type: "int", nullable: true),
                    problem_desc_plain_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_kb_pkey", x => x.kb_id);
                    table.ForeignKey(
                        name: "tbl_trn_kb_fk_kb_type_ent_id",
                        column: x => x.kb_type_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_kb_fk_source_ent_id",
                        column: x => x.source_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_problem",
                columns: table => new
                {
                    problem_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    short_desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    problem_description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    root_cause = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    symptom_code_ent_id = table.Column<int>(type: "int", nullable: true),
                    is_tested = table.Column<bool>(type: "bit", nullable: true),
                    knownerr_src_ent_id = table.Column<int>(type: "int", nullable: true),
                    knownerr_date_identified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    workaround = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_identified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closure_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    close_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closed_by_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    config_ci_id = table.Column<int>(type: "int", nullable: true),
                    impacted_ci_id = table.Column<int>(type: "int", nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    severity_ent_id = table.Column<int>(type: "int", nullable: true),
                    channel_ent_id = table.Column<int>(type: "int", nullable: true),
                    rca_date_identified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    vendor_ticket_id = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    alt_contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    caused_by_ent_id = table.Column<int>(type: "int", nullable: true),
                    create_kb_flag = table.Column<bool>(type: "bit", nullable: true),
                    resolution_criteria_ent_id = table.Column<int>(type: "int", nullable: true),
                    resolution_method_ent_id = table.Column<int>(type: "int", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    comm_email = table.Column<bool>(type: "bit", nullable: true),
                    comm_call = table.Column<bool>(type: "bit", nullable: true),
                    comm_sms = table.Column<bool>(type: "bit", nullable: true),
                    last_pri_inspection = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    last_pri_reason = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    is_major = table.Column<bool>(type: "bit", nullable: true),
                    is_arch_restore = table.Column<bool>(type: "bit", nullable: true),
                    problem_mgr_id = table.Column<int>(type: "int", nullable: true),
                    preferred_contact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    is_mpr_filled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_problem_pkey", x => x.problem_id);
                    table.ForeignKey(
                        name: "tbl_trn_problem_fk_knownerr_src_ent_id",
                        column: x => x.knownerr_src_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_problem_fk_symptom_code_ent_id",
                        column: x => x.symptom_code_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_pr_attachment",
                columns: table => new
                {
                    attachment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    binary_data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    attached_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attached_by_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_problem_attachment_pkey", x => x.attachment_id);
                    table.ForeignKey(
                        name: "tbl_trn_problem_attachment_fk_prolem_id",
                        column: x => x.record_id,
                        principalTable: "tbl_trn_problem",
                        principalColumn: "problem_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_service_request",
                columns: table => new
                {
                    service_request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    short_description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    alt_contact_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    sub_category_id = table.Column<int>(type: "int", nullable: true),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    target_fulfill_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    severity_ent_id = table.Column<int>(type: "int", nullable: true),
                    alt_location_id = table.Column<int>(type: "int", nullable: true),
                    first_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    prev_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    channel_ent_id = table.Column<int>(type: "int", nullable: true),
                    on_behalf_of_id = table.Column<int>(type: "int", nullable: true),
                    site_visit_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    additional_comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fulfillment_method_ent_id = table.Column<int>(type: "int", nullable: true),
                    kb_ref_no = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    fulfillment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fulfilled_first_time = table.Column<bool>(type: "bit", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    close_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_auto_closed = table.Column<bool>(type: "bit", nullable: true),
                    fulfillment_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    curr_assign_queue_id = table.Column<int>(type: "int", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    vendor_ticket_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fulfilled_by_id = table.Column<int>(type: "int", nullable: true),
                    has_child = table.Column<bool>(type: "bit", nullable: true),
                    config_ci_id = table.Column<int>(type: "int", nullable: true),
                    common_impact_ent_id = table.Column<int>(type: "int", nullable: true),
                    sla_breach_reason = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    email_response_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    escalation_ts_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    first_response_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fs_completed_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    misroute_ts_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    on_site_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    time_to_diagnosis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    time_to_investigate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_reopened_by_id = table.Column<int>(type: "int", nullable: true),
                    last_reopened_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reopen_count = table.Column<int>(type: "int", nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true),
                    is_arch_restore = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_service_request_pkey", x => x.service_request_id);
                    table.ForeignKey(
                        name: "tbl_trn_service_request_fk_channel_ent_id",
                        column: x => x.channel_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_service_request_fk_fulfillment_method_ent_id",
                        column: x => x.fulfillment_method_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_service_request_fk_severity_ent_id",
                        column: x => x.severity_ent_id,
                        principalTable: "tbl_mst_entity_attr",
                        principalColumn: "entity_attr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_bus_rule",
                columns: table => new
                {
                    bus_rule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    action_type = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    interval_minutes = table.Column<int>(type: "int", nullable: true),
                    recurring_count = table.Column<int>(type: "int", nullable: true),
                    sql_query_select = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    interval_type = table.Column<int>(type: "int", nullable: true),
                    stop_bus_rule_ids = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nested_bus_rule_ids = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nested_bus_rule_sql_select = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prop_change_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_conf_org_bus_rule_pkey", x => x.bus_rule_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_sla",
                columns: table => new
                {
                    sla_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    response_min = table.Column<int>(type: "int", nullable: true),
                    resolve_min = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    sla_sql_cond_start = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sla_sql_cond_pause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sla_sql_cond_stop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exclude_ops_hours = table.Column<bool>(type: "bit", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_sla_pkey", x => x.sla_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_template_queue_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true),
                    template_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_queue_template_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_org_module_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_org_module_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_sub_module",
                columns: table => new
                {
                    sub_module_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    display_text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    icon_src = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    source_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_sub_module_pkey", x => x.sub_module_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_approval",
                columns: table => new
                {
                    approval_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appr_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appr_queue_id = table.Column<int>(type: "int", nullable: true),
                    approver_id = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    approved_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    actioned_on = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    type_ent_id = table.Column<int>(type: "int", nullable: true),
                    requester_id = table.Column<int>(type: "int", nullable: true),
                    authorized_by_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_from_workflow = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_approval_pkey", x => x.approval_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_task",
                columns: table => new
                {
                    task_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    task_title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true),
                    assign_to_id = table.Column<int>(type: "int", nullable: true),
                    due_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comments_html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_draft = table.Column<bool>(type: "bit", nullable: true),
                    closed_by_id = table.Column<int>(type: "int", nullable: true),
                    closed_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_from_email_mgr = table.Column<bool>(type: "bit", nullable: true),
                    watch_list_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_notes_added_by_id = table.Column<int>(type: "int", nullable: true),
                    last_notes_added_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    approval_id = table.Column<int>(type: "int", nullable: true),
                    is_from_workflow = table.Column<bool>(type: "bit", nullable: true),
                    is_arch_restore = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_task_pkey", x => x.task_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_ad_ldap",
                columns: table => new
                {
                    ad_ldap_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    account_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    domain_name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    user_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    base_dn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    search_filter = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ldap_server_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    login_attribute = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mail_attribute = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    distinguishedName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    domain_controller = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    port = table.Column<int>(type: "int", nullable: true),
                    is_ssl = table.Column<bool>(type: "bit", nullable: true),
                    host_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    recurrence_hour = table.Column<int>(type: "int", nullable: true),
                    schedule_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_ad_ldap_pkey", x => x.ad_ldap_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_catalog_cat",
                columns: table => new
                {
                    catalog_cat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    avail_target = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    support_hours = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    icon = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_catalog_cat_pkey", x => x.catalog_cat_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_email_mgr",
                columns: table => new
                {
                    email_mgr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    protocol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    port = table.Column<int>(type: "int", nullable: true),
                    interval_min = table.Column<int>(type: "int", nullable: true),
                    is_ssl = table.Column<bool>(type: "bit", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_apply_rule = table.Column<bool>(type: "bit", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    default_category_id = table.Column<int>(type: "int", nullable: true),
                    default_item_id = table.Column<int>(type: "int", nullable: true),
                    default_priority_id = table.Column<int>(type: "int", nullable: true),
                    default_queue_id = table.Column<int>(type: "int", nullable: true),
                    default_sub_category_id = table.Column<int>(type: "int", nullable: true),
                    default_user_id = table.Column<int>(type: "int", nullable: true),
                    mail_server = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true),
                    is_extract_field = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_mail_incoming_pkey", x => x.email_mgr_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_freefrm_visborad",
                columns: table => new
                {
                    freefrm_visborad_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    board_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_freefrm_visborad_pkey", x => x.freefrm_visborad_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cnf_mail_outgoing",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    protocol = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    alt_ip_address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sender_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    sender_email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    reply_to = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    port = table.Column<int>(type: "int", nullable: true),
                    requires_auth = table.Column<bool>(type: "bit", nullable: true),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    is_default = table.Column<bool>(type: "bit", nullable: true),
                    is_ssl_enable = table.Column<bool>(type: "bit", nullable: true),
                    mail_server = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_cnf_mail_outgoing_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    head_user_id = table.Column<int>(type: "int", nullable: true),
                    incharge_user_id = table.Column<int>(type: "int", nullable: true),
                    approver_user_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_default = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_department_pkey", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_holiday",
                columns: table => new
                {
                    holiday_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    site_id = table.Column<int>(type: "int", nullable: true),
                    apply_to_org = table.Column<bool>(type: "bit", nullable: true),
                    holiday_date = table.Column<DateTime>(type: "date", nullable: true),
                    holiday_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    holiday_grp_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_holiday_pkey", x => x.holiday_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_org_queue_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_org_queue_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_org_site_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    site_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_org_site_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_sla_color",
                columns: table => new
                {
                    sla_color_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    percentage_from = table.Column<int>(type: "int", nullable: true),
                    percentage_to = table.Column<int>(type: "int", nullable: true),
                    color_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    sla_milestone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_sla_color_pkey", x => x.sla_color_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_user_org_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_user_org_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_work_hr",
                columns: table => new
                {
                    work_hr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    is_24hr = table.Column<bool>(type: "bit", nullable: true),
                    apply_to_org = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    time_zone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_work_hr_pkey", x => x.work_hr_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_wk_work_hr",
                columns: table => new
                {
                    wk_work_hr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    work_hr_id = table.Column<int>(type: "int", nullable: true),
                    week_day = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    start_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_wk_work_hr_pkey", x => x.wk_work_hr_id);
                    table.ForeignKey(
                        name: "tbl_mst_wk_work_hr_fk_work_hr_id",
                        column: x => x.work_hr_id,
                        principalTable: "tbl_mst_work_hr",
                        principalColumn: "work_hr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_impactedci",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ci_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    owner_id = table.Column<int>(type: "int", nullable: true),
                    record_id = table.Column<int>(type: "int", nullable: true),
                    module_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_problem_impactedci_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_user_queue_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    queue_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_user_queue_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_role_access_right",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    menu_id = table.Column<int>(type: "int", nullable: true),
                    can_read = table.Column<bool>(type: "bit", nullable: true),
                    can_write = table.Column<bool>(type: "bit", nullable: true),
                    action_menu_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    can_add = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_conf_access_right_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_user_role_map",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    role_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_user_role_map_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    first_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    last_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    email_id = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    mobile_no = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    site_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_vip = table.Column<bool>(type: "bit", nullable: true),
                    is_locked = table.Column<bool>(type: "bit", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    ad_username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    auth_key = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    provider = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ldap_id = table.Column<int>(type: "int", nullable: true),
                    user_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    reporting_user_id = table.Column<int>(type: "int", nullable: true),
                    designation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    vip_message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    contact_no = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    is_live_agent = table.Column<bool>(type: "bit", nullable: true),
                    is_busy = table.Column<bool>(type: "bit", nullable: true),
                    is_online = table.Column<bool>(type: "bit", nullable: true),
                    flash_id = table.Column<int>(type: "int", nullable: true),
                    is_super_admin = table.Column<bool>(type: "bit", nullable: true),
                    secondary_contact_no = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    secondary_email_id = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_user_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_module",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    options = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_index = table.Column<int>(type: "int", nullable: true),
                    main_table_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pk_column_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_module_pkey", x => x.module_id);
                    table.ForeignKey(
                        name: "tbl_mst_module_fk_created_by",
                        column: x => x.created_by_id,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_mst_module_fk_modified_by",
                        column: x => x.modified_by_id,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_org",
                columns: table => new
                {
                    org_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    support_email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    sender_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    login_img = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    header_img = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    email_id = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    web_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    advisary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by_id = table.Column<int>(type: "int", nullable: true),
                    ho_address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    zipcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    self_service_queue_Id = table.Column<int>(type: "int", nullable: true),
                    country = table.Column<int>(type: "int", nullable: true),
                    state = table.Column<int>(type: "int", nullable: true),
                    city = table.Column<int>(type: "int", nullable: true),
                    time_zone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    is_dept_wise_cti = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_organization_pkey", x => x.org_id);
                    table.ForeignKey(
                        name: "tbl_mst_org_fk_created_by",
                        column: x => x.created_by_id,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_mst_org_fk_modified_by",
                        column: x => x.modified_by_id,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_queue",
                columns: table => new
                {
                    queue_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    email_id_json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mail_to_group = table.Column<bool>(type: "bit", nullable: true),
                    mail_to_group_member = table.Column<bool>(type: "bit", nullable: true),
                    queue_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_queue_pkey", x => x.queue_id);
                    table.ForeignKey(
                        name: "tbl_mst_queue_fk_created_by",
                        column: x => x.created_by,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_mst_queue_fk_modified_by",
                        column: x => x.modified_by,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    user_type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    is_super_admin = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_role_pkey", x => x.role_id);
                    table.ForeignKey(
                        name: "tbl_mst_role_fk_created_by",
                        column: x => x.created_by,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_mst_role_fk_modified_by",
                        column: x => x.modified_by,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_site",
                columns: table => new
                {
                    site_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    primary_addr1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    primary_addr2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    primary_zipcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    secondary_addr1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    secondary_addr2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    secondary_zipcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    primary_country = table.Column<int>(type: "int", nullable: true),
                    primary_state = table.Column<int>(type: "int", nullable: true),
                    primary_city = table.Column<int>(type: "int", nullable: true),
                    secondary_country = table.Column<int>(type: "int", nullable: true),
                    secondary_state = table.Column<int>(type: "int", nullable: true),
                    secondary_city = table.Column<int>(type: "int", nullable: true),
                    work_hr_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_site_pkey", x => x.site_id);
                    table.ForeignKey(
                        name: "tbl_mst_site_fk_created_by",
                        column: x => x.created_by,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_mst_site_fk_modified_by",
                        column: x => x.modified_by,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mst_user_profile",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    language = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    time_zone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    date_format = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    time_format = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email_signature = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    auth_key = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    profile_pic = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    firebase_session_id_android = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firebase_session_id_ios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_mst_user_profile_pkey", x => x.uid);
                    table.ForeignKey(
                        name: "tbl_mst_user_profile_fk_created_by",
                        column: x => x.created_by,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_mst_user_profile_fk_modified_by",
                        column: x => x.modified_by,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_mst_user_profile_fk_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_freefrm_visborad_assignto",
                columns: table => new
                {
                    freefrm_visborad_assignto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    freefrm_visborad_card_id = table.Column<int>(type: "int", nullable: true),
                    addl_assign_to_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_freefrm_visborad_assignto_pkey", x => x.freefrm_visborad_assignto_id);
                    table.ForeignKey(
                        name: "tbl_trn_freefrm_visborad_assignto_fk_addl_assign_to_id",
                        column: x => x.addl_assign_to_id,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_freefrm_visborad_assignto_fk_freefrm_visborad_card_id",
                        column: x => x.freefrm_visborad_card_id,
                        principalTable: "tbl_trn_freefrm_visborad_card",
                        principalColumn: "freefrm_visborad_card_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_trn_kb_comment",
                columns: table => new
                {
                    kb_comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kb_id = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    parent_comment_id = table.Column<int>(type: "int", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rating = table.Column<decimal>(type: "numeric(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_trn_kb_comment_pkey", x => x.kb_comment_id);
                    table.ForeignKey(
                        name: "tbl_trn_kb_comment_fk_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "tbl_mst_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tbl_trn_kb_comment_fk_kb_id",
                        column: x => x.kb_id,
                        principalTable: "tbl_trn_kb",
                        principalColumn: "kb_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "uc_profile_name",
                table: "bot_master_profile",
                column: "profile_name",
                unique: true,
                filter: "([profile_name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "uc_active_year",
                table: "bot_system_term",
                column: "active_year",
                unique: true,
                filter: "[active_year] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "uc_user_employee_code",
                table: "bot_user_details",
                column: "user_employee_code",
                unique: true,
                filter: "[user_employee_code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "uc_username",
                table: "bot_user_login",
                column: "user_login_name",
                unique: true,
                filter: "([user_login_name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_autodisc_mst_discovery_ip_address_discovery_id",
                table: "tbl_autodisc_mst_discovery_ip_address",
                column: "discovery_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_autodisc_mst_discovery_rule_action_discovery_rule_id",
                table: "tbl_autodisc_mst_discovery_rule_action",
                column: "discovery_rule_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_autodisc_mst_discovery_rule_condition_discovery_rule_id",
                table: "tbl_autodisc_mst_discovery_rule_condition",
                column: "discovery_rule_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_autodisc_trn_discovery_detail_trn_discovery_id",
                table: "tbl_autodisc_trn_discovery_detail",
                column: "trn_discovery_id");

            migrationBuilder.CreateIndex(
                name: "uc_group_name",
                table: "tbl_cha_user_groups",
                column: "group_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uc_group_code_user_code",
                table: "tbl_cha_user_groups_details",
                columns: new[] { "group_code", "user_code" },
                unique: true,
                filter: "[group_code] IS NOT NULL AND [user_code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "uc_visitor_user_id",
                table: "tbl_cha_visitor_queue",
                column: "visitor_user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "tbl_cmdb_trn_ci_id_number_idx",
                table: "tbl_cmdb_trn_ci",
                column: "id_number",
                unique: true,
                filter: "[id_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_ad_ldap_org_id",
                table: "tbl_cnf_ad_ldap",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_ad_ldap_field_map_ad_ldap_id",
                table: "tbl_cnf_ad_ldap_field_map",
                column: "ad_ldap_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_ad_schedule_ad_ldap_id",
                table: "tbl_cnf_ad_schedule",
                column: "ad_ldap_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_bus_rule_module_id",
                table: "tbl_cnf_bus_rule",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_bus_rule_org_id",
                table: "tbl_cnf_bus_rule",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_bus_rule_action_bus_rule_id",
                table: "tbl_cnf_bus_rule_action",
                column: "bus_rule_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_bus_rule_cond_bus_rule_id",
                table: "tbl_cnf_bus_rule_cond",
                column: "bus_rule_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_bus_rule_cond_form_field_id",
                table: "tbl_cnf_bus_rule_cond",
                column: "form_field_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_catalog_cat_org_id",
                table: "tbl_cnf_catalog_cat",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_catalog_question_dtls_catalog_question_id",
                table: "tbl_cnf_catalog_question_dtls",
                column: "catalog_question_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_catalog_resource_catalog_question_id",
                table: "tbl_cnf_catalog_resource",
                column: "catalog_question_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_catalog_resource_dtls_catalog_resource_id",
                table: "tbl_cnf_catalog_resource_dtls",
                column: "catalog_resource_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_data_archive_cond_archive_id",
                table: "tbl_cnf_data_archive_cond",
                column: "archive_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_data_archive_cond_form_field_id",
                table: "tbl_cnf_data_archive_cond",
                column: "form_field_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_datadrive_visborad_created_by_id",
                table: "tbl_cnf_datadrive_visborad",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_datadrive_visborad_modified_by_id",
                table: "tbl_cnf_datadrive_visborad",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_datadrive_visborad_swim_form_field_id",
                table: "tbl_cnf_datadrive_visborad",
                column: "swim_form_field_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_datadrive_visborad_vertlane_form_field_id",
                table: "tbl_cnf_datadrive_visborad",
                column: "vertlane_form_field_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_email_mgr_created_by_id",
                table: "tbl_cnf_email_mgr",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_email_mgr_modified_by_id",
                table: "tbl_cnf_email_mgr",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_email_mgr_org_id",
                table: "tbl_cnf_email_mgr",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_email_mgr_extract_field_email_mgr_id",
                table: "tbl_cnf_email_mgr_extract_field",
                column: "email_mgr_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_email_mgr_rule_email_mgr_id",
                table: "tbl_cnf_email_mgr_rule",
                column: "email_mgr_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_freefrm_visborad_org_id",
                table: "tbl_cnf_freefrm_visborad",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_freefrm_visborad_lane_freefrm_visborad_id",
                table: "tbl_cnf_freefrm_visborad_lane",
                column: "freefrm_visborad_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_mail_outgoing_created_by",
                table: "tbl_cnf_mail_outgoing",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_mail_outgoing_modified_by",
                table: "tbl_cnf_mail_outgoing",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_mail_outgoing_org_id",
                table: "tbl_cnf_mail_outgoing",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_notify_rule_email_template_id",
                table: "tbl_cnf_notify_rule",
                column: "email_template_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_notify_rule_module_id",
                table: "tbl_cnf_notify_rule",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_sla_module_id",
                table: "tbl_cnf_sla",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_sla_org_id",
                table: "tbl_cnf_sla",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_sla_action_sla_id",
                table: "tbl_cnf_sla_action",
                column: "sla_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_sla_cond_form_field_id",
                table: "tbl_cnf_sla_cond",
                column: "form_field_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_sla_cond_sla_id",
                table: "tbl_cnf_sla_cond",
                column: "sla_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_template_queue_map_module_id",
                table: "tbl_cnf_template_queue_map",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cnf_template_queue_map_queue_id",
                table: "tbl_cnf_template_queue_map",
                column: "queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_admin_activity_log_module_id",
                table: "tbl_mst_admin_activity_log",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_db_view_column_db_view_id",
                table: "tbl_mst_db_view_column",
                column: "db_view_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_department_approver_user_id",
                table: "tbl_mst_department",
                column: "approver_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_department_head_user_id",
                table: "tbl_mst_department",
                column: "head_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_department_incharge_user_id",
                table: "tbl_mst_department",
                column: "incharge_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_department_org_id",
                table: "tbl_mst_department",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "tbl_mst_entity_name_idx",
                table: "tbl_mst_entity",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "tbl_mst_entity_attr_entity_id_idx",
                table: "tbl_mst_entity_attr",
                column: "entity_id");

            migrationBuilder.CreateIndex(
                name: "tbl_mst_entity_attr_org_id_idx",
                table: "tbl_mst_entity_attr",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_holiday_org_id",
                table: "tbl_mst_holiday",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_holiday_site_id",
                table: "tbl_mst_holiday",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_module_created_by_id",
                table: "tbl_mst_module",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_module_modified_by_id",
                table: "tbl_mst_module",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_module_cust_field_role_mapper_field_uid",
                table: "tbl_mst_module_cust_field_role_mapper",
                column: "field_uid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_created_by_id",
                table: "tbl_mst_org",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_modified_by_id",
                table: "tbl_mst_org",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_module_map_created_by",
                table: "tbl_mst_org_module_map",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_module_map_modified_by",
                table: "tbl_mst_org_module_map",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_module_map_module_id",
                table: "tbl_mst_org_module_map",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_module_map_org_id",
                table: "tbl_mst_org_module_map",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_queue_map_org_id",
                table: "tbl_mst_org_queue_map",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_queue_map_queue_id",
                table: "tbl_mst_org_queue_map",
                column: "queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_site_map_org_id",
                table: "tbl_mst_org_site_map",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_org_site_map_site_id",
                table: "tbl_mst_org_site_map",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_queue_created_by",
                table: "tbl_mst_queue",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_queue_modified_by",
                table: "tbl_mst_queue",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_role_created_by",
                table: "tbl_mst_role",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_role_modified_by",
                table: "tbl_mst_role",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_role_access_right_role_id",
                table: "tbl_mst_role_access_right",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_site_created_by",
                table: "tbl_mst_site",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_site_modified_by",
                table: "tbl_mst_site",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_sla_color_org_id",
                table: "tbl_mst_sla_color",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_sub_module_created_by",
                table: "tbl_mst_sub_module",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_sub_module_modified_by",
                table: "tbl_mst_sub_module",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_sub_module_module_id",
                table: "tbl_mst_sub_module",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_site_id",
                table: "tbl_mst_user",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_org_map_created_by",
                table: "tbl_mst_user_org_map",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_org_map_modified_by",
                table: "tbl_mst_user_org_map",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_org_map_org_id",
                table: "tbl_mst_user_org_map",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_org_map_user_id",
                table: "tbl_mst_user_org_map",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_profile_created_by",
                table: "tbl_mst_user_profile",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_profile_modified_by",
                table: "tbl_mst_user_profile",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_profile_user_id",
                table: "tbl_mst_user_profile",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_queue_map_queue_id",
                table: "tbl_mst_user_queue_map",
                column: "queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_queue_map_user_id",
                table: "tbl_mst_user_queue_map",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_role_map_role_Id",
                table: "tbl_mst_user_role_map",
                column: "role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_user_role_map_user_id",
                table: "tbl_mst_user_role_map",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_wk_work_hr_work_hr_id",
                table: "tbl_mst_wk_work_hr",
                column: "work_hr_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mst_work_hr_org_id",
                table: "tbl_mst_work_hr",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_survey_mst_form_attachment_id",
                table: "tbl_survey_mst_form",
                column: "attachment_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_survey_mst_form_question_survey_form_id",
                table: "tbl_survey_mst_form_question",
                column: "survey_form_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_survey_mst_form_question_detail_question_id",
                table: "tbl_survey_mst_form_question_detail",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_approval_appr_queue_id",
                table: "tbl_trn_approval",
                column: "appr_queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_approval_approver_id",
                table: "tbl_trn_approval",
                column: "approver_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_approval_created_by_id",
                table: "tbl_trn_approval",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_approval_modified_by_id",
                table: "tbl_trn_approval",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_approval_module_id",
                table: "tbl_trn_approval",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "tbl_trn_approval_id_number_idx",
                table: "tbl_trn_approval",
                column: "id_number",
                unique: true,
                filter: "[id_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_catalog_order_catalog_resource_dtls_id",
                table: "tbl_trn_catalog_order",
                column: "catalog_resource_dtls_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_catalog_order_service_request_id",
                table: "tbl_trn_catalog_order",
                column: "service_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_change_assign_to_id",
                table: "tbl_trn_change",
                column: "assign_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_change_created_by_id",
                table: "tbl_trn_change",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_change_curr_assign_queue_id",
                table: "tbl_trn_change",
                column: "curr_assign_queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_change_first_assign_queue_id",
                table: "tbl_trn_change",
                column: "first_assign_queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_change_modified_by_id",
                table: "tbl_trn_change",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_change_org_id",
                table: "tbl_trn_change",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_change_prev_assign_queue_id",
                table: "tbl_trn_change",
                column: "prev_assign_queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_change_risk_ent_id",
                table: "tbl_trn_change",
                column: "risk_ent_id");

            migrationBuilder.CreateIndex(
                name: "tbl_trn_change_id_number_idx",
                table: "tbl_trn_change",
                column: "id_number",
                unique: true,
                filter: "[id_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_cr_attachment_record_id",
                table: "tbl_trn_cr_attachment",
                column: "record_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_cr_details_availability_ent_id",
                table: "tbl_trn_cr_details",
                column: "availability_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_cr_details_backout_duration_ent_id",
                table: "tbl_trn_cr_details",
                column: "backout_duration_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_cr_details_backup_tested_ent_id",
                table: "tbl_trn_cr_details",
                column: "backup_tested_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_cr_details_failover_available_ent_id",
                table: "tbl_trn_cr_details",
                column: "failover_available_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_cr_details_previously_executed_ent_id",
                table: "tbl_trn_cr_details",
                column: "previously_executed_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_cr_details_third_party_support_ent_id",
                table: "tbl_trn_cr_details",
                column: "third_party_support_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_cr_details_users_impacted_ent_id",
                table: "tbl_trn_cr_details",
                column: "users_impacted_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_freefrm_visborad_assignto_addl_assign_to_id",
                table: "tbl_trn_freefrm_visborad_assignto",
                column: "addl_assign_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_freefrm_visborad_assignto_freefrm_visborad_card_id",
                table: "tbl_trn_freefrm_visborad_assignto",
                column: "freefrm_visborad_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_freefrm_visborad_attach_freefrm_visborad_card_id",
                table: "tbl_trn_freefrm_visborad_attach",
                column: "freefrm_visborad_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_freefrm_visborad_card_assign_to_id",
                table: "tbl_trn_freefrm_visborad_card",
                column: "assign_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_freefrm_visborad_card_created_by_id",
                table: "tbl_trn_freefrm_visborad_card",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_freefrm_visborad_card_modified_by_id",
                table: "tbl_trn_freefrm_visborad_card",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_freefrm_visborad_chklist_freefrm_visborad_card_id",
                table: "tbl_trn_freefrm_visborad_chklist",
                column: "freefrm_visborad_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_freefrm_visborad_label_freefrm_visborad_card_id",
                table: "tbl_trn_freefrm_visborad_label",
                column: "freefrm_visborad_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_freefrm_visborad_note_freefrm_visborad_card_id",
                table: "tbl_trn_freefrm_visborad_note",
                column: "freefrm_visborad_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_impactedci_org_id",
                table: "tbl_trn_impactedci",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_impactedci_owner_id",
                table: "tbl_trn_impactedci",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_alt_location_id",
                table: "tbl_trn_incident",
                column: "alt_location_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_assign_to_id",
                table: "tbl_trn_incident",
                column: "assign_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_caused_by_ent_id",
                table: "tbl_trn_incident",
                column: "caused_by_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_channel_ent_id",
                table: "tbl_trn_incident",
                column: "channel_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_created_by_id",
                table: "tbl_trn_incident",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_location_id",
                table: "tbl_trn_incident",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_modified_by_id",
                table: "tbl_trn_incident",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_nefcr_desc_ent_id",
                table: "tbl_trn_incident",
                column: "nefcr_desc_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_on_behalf_of_id",
                table: "tbl_trn_incident",
                column: "on_behalf_of_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_org_id",
                table: "tbl_trn_incident",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_resolution_criteria_ent_id",
                table: "tbl_trn_incident",
                column: "resolution_criteria_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_resolution_method_ent_id",
                table: "tbl_trn_incident",
                column: "resolution_method_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_resolved_by_id",
                table: "tbl_trn_incident",
                column: "resolved_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_severity_ent_id",
                table: "tbl_trn_incident",
                column: "severity_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_incident_user_id",
                table: "tbl_trn_incident",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "tbl_trn_incident_id_number_idx",
                table: "tbl_trn_incident",
                column: "id_number",
                unique: true,
                filter: "[id_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_kb_assign_to_id",
                table: "tbl_trn_kb",
                column: "assign_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_kb_created_by_id",
                table: "tbl_trn_kb",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_kb_kb_type_ent_id",
                table: "tbl_trn_kb",
                column: "kb_type_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_kb_modified_by_id",
                table: "tbl_trn_kb",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_kb_org_id",
                table: "tbl_trn_kb",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_kb_source_ent_id",
                table: "tbl_trn_kb",
                column: "source_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_kb_comment_created_by_id",
                table: "tbl_trn_kb_comment",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_kb_comment_kb_id",
                table: "tbl_trn_kb_comment",
                column: "kb_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_pr_attachment_record_id",
                table: "tbl_trn_pr_attachment",
                column: "record_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_assign_to_id",
                table: "tbl_trn_problem",
                column: "assign_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_created_by_id",
                table: "tbl_trn_problem",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_curr_assign_queue_id",
                table: "tbl_trn_problem",
                column: "curr_assign_queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_first_assign_queue_id",
                table: "tbl_trn_problem",
                column: "first_assign_queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_knownerr_src_ent_id",
                table: "tbl_trn_problem",
                column: "knownerr_src_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_modified_by_id",
                table: "tbl_trn_problem",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_org_id",
                table: "tbl_trn_problem",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_prev_assign_queue_id",
                table: "tbl_trn_problem",
                column: "prev_assign_queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_symptom_code_ent_id",
                table: "tbl_trn_problem",
                column: "symptom_code_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_problem_user_id",
                table: "tbl_trn_problem",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "tbl_trn_problem_id_number_idx",
                table: "tbl_trn_problem",
                column: "id_number",
                unique: true,
                filter: "[id_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_alt_location_id",
                table: "tbl_trn_service_request",
                column: "alt_location_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_assign_to_id",
                table: "tbl_trn_service_request",
                column: "assign_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_channel_ent_id",
                table: "tbl_trn_service_request",
                column: "channel_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_created_by_id",
                table: "tbl_trn_service_request",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_first_assign_queue_id",
                table: "tbl_trn_service_request",
                column: "first_assign_queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_fulfillment_method_ent_id",
                table: "tbl_trn_service_request",
                column: "fulfillment_method_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_location_id",
                table: "tbl_trn_service_request",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_modified_by_id",
                table: "tbl_trn_service_request",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_org_id",
                table: "tbl_trn_service_request",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_prev_assign_queue_id",
                table: "tbl_trn_service_request",
                column: "prev_assign_queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_severity_ent_id",
                table: "tbl_trn_service_request",
                column: "severity_ent_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_service_request_user_id",
                table: "tbl_trn_service_request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "tbl_trn_service_request_id_number_idx",
                table: "tbl_trn_service_request",
                column: "id_number",
                unique: true,
                filter: "[id_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_task_assign_to_id",
                table: "tbl_trn_task",
                column: "assign_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_task_closed_by_id",
                table: "tbl_trn_task",
                column: "closed_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_task_created_by_id",
                table: "tbl_trn_task",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_task_modified_by_id",
                table: "tbl_trn_task",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_task_module_id",
                table: "tbl_trn_task",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_task_org_id",
                table: "tbl_trn_task",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_task_queue_id",
                table: "tbl_trn_task",
                column: "queue_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_task_user_id",
                table: "tbl_trn_task",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "tbl_trn_task_id_number_idx",
                table: "tbl_trn_task",
                column: "id_number",
                unique: true,
                filter: "[id_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_ticket_cust_field_detail_field_uid",
                table: "tbl_trn_ticket_cust_field_detail",
                column: "field_uid");

            migrationBuilder.CreateIndex(
                name: "tbl_trn_ticket_sla_record_id_idx",
                table: "tbl_trn_ticket_sla",
                columns: new[] { "record_id", "module_id" });

            migrationBuilder.CreateIndex(
                name: "idx_record_module_id",
                table: "tbl_trn_ticket_spent_time",
                columns: new[] { "record_id", "module_id" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_trn_ticket_survey_question_survey_id",
                table: "tbl_trn_ticket_survey_question",
                column: "survey_id");

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_ad_ldap_field_map_fk_ad_ldap_id",
                table: "tbl_cnf_ad_ldap_field_map",
                column: "ad_ldap_id",
                principalTable: "tbl_cnf_ad_ldap",
                principalColumn: "ad_ldap_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_ad_schedule_fk_ad_ldap_id",
                table: "tbl_cnf_ad_schedule",
                column: "ad_ldap_id",
                principalTable: "tbl_cnf_ad_ldap",
                principalColumn: "ad_ldap_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_rule_cond_fk_bus_rule_id",
                table: "tbl_cnf_bus_rule_cond",
                column: "bus_rule_id",
                principalTable: "tbl_cnf_bus_rule",
                principalColumn: "bus_rule_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_datadrive_visborad_fk_created_by_id",
                table: "tbl_cnf_datadrive_visborad",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_datadrive_visborad_fk_modified_by_id",
                table: "tbl_cnf_datadrive_visborad",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_sla_cond_fk_sla_id",
                table: "tbl_cnf_sla_cond",
                column: "sla_id",
                principalTable: "tbl_cnf_sla",
                principalColumn: "sla_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_rule_action_fk_bus_rule_id",
                table: "tbl_cnf_bus_rule_action",
                column: "bus_rule_id",
                principalTable: "tbl_cnf_bus_rule",
                principalColumn: "bus_rule_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_catalog_order_fk_service_request_id",
                table: "tbl_trn_catalog_order",
                column: "service_request_id",
                principalTable: "tbl_trn_service_request",
                principalColumn: "service_request_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_email_mgr_extract_field_fk",
                table: "tbl_cnf_email_mgr_extract_field",
                column: "email_mgr_id",
                principalTable: "tbl_cnf_email_mgr",
                principalColumn: "email_mgr_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_email_mgr_rule_fk_mail_incoming_id",
                table: "tbl_cnf_email_mgr_rule",
                column: "email_mgr_id",
                principalTable: "tbl_cnf_email_mgr",
                principalColumn: "email_mgr_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_notification_fk_module_id",
                table: "tbl_cnf_notify_rule",
                column: "module_id",
                principalTable: "tbl_mst_module",
                principalColumn: "module_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_freefrm_visborad_lane_fk_freefrm_visboard_id",
                table: "tbl_cnf_freefrm_visborad_lane",
                column: "freefrm_visborad_id",
                principalTable: "tbl_cnf_freefrm_visborad",
                principalColumn: "freefrm_visborad_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_freefrm_visborad_card_fk_assign_to_id",
                table: "tbl_trn_freefrm_visborad_card",
                column: "assign_to_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_freefrm_visborad_card_fk_created_by_id",
                table: "tbl_trn_freefrm_visborad_card",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_freefrm_visborad_card_fk_modified_by_id",
                table: "tbl_trn_freefrm_visborad_card",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_sla_action_fk_sla_id",
                table: "tbl_cnf_sla_action",
                column: "sla_id",
                principalTable: "tbl_cnf_sla",
                principalColumn: "sla_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_change_fk_assign_to_id",
                table: "tbl_trn_change",
                column: "assign_to_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_change_fk_created_by_id",
                table: "tbl_trn_change",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_change_fk_modified_by_id",
                table: "tbl_trn_change",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_change_fk_curr_assign_queue_id",
                table: "tbl_trn_change",
                column: "curr_assign_queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_change_fk_first_assign_queue_id",
                table: "tbl_trn_change",
                column: "first_assign_queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_change_fk_prev_assign_queue_id",
                table: "tbl_trn_change",
                column: "prev_assign_queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_change_fk_org_id",
                table: "tbl_trn_change",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_incident_fk_alt_location_id",
                table: "tbl_trn_incident",
                column: "alt_location_id",
                principalTable: "tbl_mst_site",
                principalColumn: "site_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_incident_fk_location_id",
                table: "tbl_trn_incident",
                column: "location_id",
                principalTable: "tbl_mst_site",
                principalColumn: "site_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_incident_fk_assign_to_id",
                table: "tbl_trn_incident",
                column: "assign_to_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_incident_fk_created_by_id",
                table: "tbl_trn_incident",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_incident_fk_modified_by_id",
                table: "tbl_trn_incident",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_incident_fk_on_behalf_of_id",
                table: "tbl_trn_incident",
                column: "on_behalf_of_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_incident_fk_resolved_by_id",
                table: "tbl_trn_incident",
                column: "resolved_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_incident_fk_user_id",
                table: "tbl_trn_incident",
                column: "user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_incident_fk_org_id",
                table: "tbl_trn_incident",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_kb_fk_assign_to_id",
                table: "tbl_trn_kb",
                column: "assign_to_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_kb_fk_created_by_id",
                table: "tbl_trn_kb",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_kb_fk_modified_by_id",
                table: "tbl_trn_kb",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_kb_fk_org_id",
                table: "tbl_trn_kb",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_fk_assign_to_id",
                table: "tbl_trn_problem",
                column: "assign_to_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_fk_created_by_id",
                table: "tbl_trn_problem",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_fk_modified_by_id",
                table: "tbl_trn_problem",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_fk_user_id",
                table: "tbl_trn_problem",
                column: "user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_fk_curr_assign_queue_id",
                table: "tbl_trn_problem",
                column: "curr_assign_queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_fk_first_assign_queue_id",
                table: "tbl_trn_problem",
                column: "first_assign_queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_fk_prev_assign_queue_id",
                table: "tbl_trn_problem",
                column: "prev_assign_queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_fk_org_id",
                table: "tbl_trn_problem",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_service_request_fk_alt_location_id",
                table: "tbl_trn_service_request",
                column: "alt_location_id",
                principalTable: "tbl_mst_site",
                principalColumn: "site_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_service_request_fk_location_id",
                table: "tbl_trn_service_request",
                column: "location_id",
                principalTable: "tbl_mst_site",
                principalColumn: "site_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_service_request_fk_assign_to_id",
                table: "tbl_trn_service_request",
                column: "assign_to_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_service_request_fk_created_by_id",
                table: "tbl_trn_service_request",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_service_request_fk_modified_by_id",
                table: "tbl_trn_service_request",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_service_request_fk_user_id",
                table: "tbl_trn_service_request",
                column: "user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_service_request_fk_first_assign_queue_id",
                table: "tbl_trn_service_request",
                column: "first_assign_queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_service_request_fk_prev_assign_queue_id",
                table: "tbl_trn_service_request",
                column: "prev_assign_queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_service_request_fk_org_id",
                table: "tbl_trn_service_request",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_bus_rule_fk_module_id",
                table: "tbl_cnf_bus_rule",
                column: "module_id",
                principalTable: "tbl_mst_module",
                principalColumn: "module_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_bus_rule_fk_org_id",
                table: "tbl_cnf_bus_rule",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_sla_fk_org_id",
                table: "tbl_cnf_sla",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_sla_module_id",
                table: "tbl_cnf_sla",
                column: "module_id",
                principalTable: "tbl_mst_module",
                principalColumn: "module_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_queue_template_map_fk_module_id",
                table: "tbl_cnf_template_queue_map",
                column: "module_id",
                principalTable: "tbl_mst_module",
                principalColumn: "module_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_queue_template_map_queue_id",
                table: "tbl_cnf_template_queue_map",
                column: "queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_org_module_map_fk_created_by",
                table: "tbl_mst_org_module_map",
                column: "created_by",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_org_module_map_fk_modified_by",
                table: "tbl_mst_org_module_map",
                column: "modified_by",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_org_module_map_fk_module_id",
                table: "tbl_mst_org_module_map",
                column: "module_id",
                principalTable: "tbl_mst_module",
                principalColumn: "module_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_org_module_map_fk_org_id",
                table: "tbl_mst_org_module_map",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_sub_module_fk_created_by",
                table: "tbl_mst_sub_module",
                column: "created_by",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_sub_module_fk_modified_by",
                table: "tbl_mst_sub_module",
                column: "modified_by",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_sub_module_fk_module_id",
                table: "tbl_mst_sub_module",
                column: "module_id",
                principalTable: "tbl_mst_module",
                principalColumn: "module_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_approval_fk_appr_queue_id",
                table: "tbl_trn_approval",
                column: "appr_queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_approval_fk_approver_id",
                table: "tbl_trn_approval",
                column: "approver_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_approval_fk_created_by_id",
                table: "tbl_trn_approval",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_approval_fk_modified_by_id",
                table: "tbl_trn_approval",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_approval_fk_module_id",
                table: "tbl_trn_approval",
                column: "module_id",
                principalTable: "tbl_mst_module",
                principalColumn: "module_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "assign_to_id",
                table: "tbl_trn_task",
                column: "assign_to_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_task_fk_closed_by_id",
                table: "tbl_trn_task",
                column: "closed_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_task_fk_created_by_id",
                table: "tbl_trn_task",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_task_fk_modified_by_id",
                table: "tbl_trn_task",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_task_fk_user_id",
                table: "tbl_trn_task",
                column: "user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_task_fk_module_id",
                table: "tbl_trn_task",
                column: "module_id",
                principalTable: "tbl_mst_module",
                principalColumn: "module_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_task_fk_org_id",
                table: "tbl_trn_task",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_task_fk_queue_id",
                table: "tbl_trn_task",
                column: "queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_ad_ldap_fk_org_id",
                table: "tbl_cnf_ad_ldap",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_catalog_cat_fk_org_id",
                table: "tbl_cnf_catalog_cat",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_mail_incoming_fk_created_by",
                table: "tbl_cnf_email_mgr",
                column: "created_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_mail_incoming_fk_modified_by",
                table: "tbl_cnf_email_mgr",
                column: "modified_by_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_mail_incoming_fk_org_id",
                table: "tbl_cnf_email_mgr",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_freefrm_visborad_fk_org_id",
                table: "tbl_cnf_freefrm_visborad",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_mail_outgoing_fk_created_by",
                table: "tbl_cnf_mail_outgoing",
                column: "created_by",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_mail_outgoing_fk_modified_by",
                table: "tbl_cnf_mail_outgoing",
                column: "modified_by",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_cnf_mail_outgoing_fk_org_id",
                table: "tbl_cnf_mail_outgoing",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_department_fk_approver_id",
                table: "tbl_mst_department",
                column: "approver_user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_department_fk_head_id",
                table: "tbl_mst_department",
                column: "head_user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_department_fk_incharge_id",
                table: "tbl_mst_department",
                column: "incharge_user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_department_fk_org_id",
                table: "tbl_mst_department",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_holiday_fk_org_id",
                table: "tbl_mst_holiday",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_holiday_fk_site_id",
                table: "tbl_mst_holiday",
                column: "site_id",
                principalTable: "tbl_mst_site",
                principalColumn: "site_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_org_queue_map_fk_org_id",
                table: "tbl_mst_org_queue_map",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_org_queue_map_fk_queue_id",
                table: "tbl_mst_org_queue_map",
                column: "queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_org_site_map_fk_org_id",
                table: "tbl_mst_org_site_map",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_org_site_map_fk_site_id",
                table: "tbl_mst_org_site_map",
                column: "site_id",
                principalTable: "tbl_mst_site",
                principalColumn: "site_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_sla_color_fk_org_id",
                table: "tbl_mst_sla_color",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_user_org_map_fk_created_by",
                table: "tbl_mst_user_org_map",
                column: "created_by",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_user_org_map_fk_modified_by",
                table: "tbl_mst_user_org_map",
                column: "modified_by",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_user_org_map_fk_user_id",
                table: "tbl_mst_user_org_map",
                column: "user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_user_org_map_fk_org_id",
                table: "tbl_mst_user_org_map",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_work_hr_fk_org_id",
                table: "tbl_mst_work_hr",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_impactedci_fk_org_id",
                table: "tbl_trn_impactedci",
                column: "org_id",
                principalTable: "tbl_mst_org",
                principalColumn: "org_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_trn_problem_impactedci_fk_owner_id",
                table: "tbl_trn_impactedci",
                column: "owner_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_user_queue_map_fk_user_id",
                table: "tbl_mst_user_queue_map",
                column: "user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_user_queue_map_queue_id",
                table: "tbl_mst_user_queue_map",
                column: "queue_id",
                principalTable: "tbl_mst_queue",
                principalColumn: "queue_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_conf_access_right_fk_role_id",
                table: "tbl_mst_role_access_right",
                column: "role_id",
                principalTable: "tbl_mst_role",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_user_role_map_fk_role_id",
                table: "tbl_mst_user_role_map",
                column: "role_Id",
                principalTable: "tbl_mst_role",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_user_role_map_fk_user_id",
                table: "tbl_mst_user_role_map",
                column: "user_id",
                principalTable: "tbl_mst_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tbl_mst_user_fk_site_id",
                table: "tbl_mst_user",
                column: "site_id",
                principalTable: "tbl_mst_site",
                principalColumn: "site_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "tbl_mst_site_fk_created_by",
                table: "tbl_mst_site");

            migrationBuilder.DropForeignKey(
                name: "tbl_mst_site_fk_modified_by",
                table: "tbl_mst_site");

            migrationBuilder.DropTable(
                name: "arch_cnf_follow_up");

            migrationBuilder.DropTable(
                name: "arch_trn_appr_attachment");

            migrationBuilder.DropTable(
                name: "arch_trn_approval");

            migrationBuilder.DropTable(
                name: "arch_trn_inc_activity_log");

            migrationBuilder.DropTable(
                name: "arch_trn_inc_attachment");

            migrationBuilder.DropTable(
                name: "arch_trn_inc_notes_log");

            migrationBuilder.DropTable(
                name: "arch_trn_incident");

            migrationBuilder.DropTable(
                name: "arch_trn_pr_activity_log");

            migrationBuilder.DropTable(
                name: "arch_trn_pr_attachment");

            migrationBuilder.DropTable(
                name: "arch_trn_pr_notes_log");

            migrationBuilder.DropTable(
                name: "arch_trn_problem");

            migrationBuilder.DropTable(
                name: "arch_trn_task");

            migrationBuilder.DropTable(
                name: "arch_trn_task_activity_log");

            migrationBuilder.DropTable(
                name: "arch_trn_task_attachment");

            migrationBuilder.DropTable(
                name: "arch_trn_task_notes_log");

            migrationBuilder.DropTable(
                name: "arch_trn_ticket_link");

            migrationBuilder.DropTable(
                name: "bot_master_menu");

            migrationBuilder.DropTable(
                name: "bot_master_profile");

            migrationBuilder.DropTable(
                name: "bot_message");

            migrationBuilder.DropTable(
                name: "bot_message_details");

            migrationBuilder.DropTable(
                name: "bot_profile_detail");

            migrationBuilder.DropTable(
                name: "bot_system_configuration");

            migrationBuilder.DropTable(
                name: "bot_system_reports_setting");

            migrationBuilder.DropTable(
                name: "bot_system_term");

            migrationBuilder.DropTable(
                name: "bot_user_details");

            migrationBuilder.DropTable(
                name: "bot_user_login");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_cnf_wmi_command");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mac_info");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mst_credential");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mst_discovery_ip_address");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mst_discovery_rule_action");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mst_discovery_rule_condition");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mst_discovery_schedule");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mst_mib");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mst_protocol");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_trn_discovery_detail");

            migrationBuilder.DropTable(
                name: "tbl_cha_user_chat_message");

            migrationBuilder.DropTable(
                name: "tbl_cha_user_chat_session");

            migrationBuilder.DropTable(
                name: "tbl_cha_user_group_message");

            migrationBuilder.DropTable(
                name: "tbl_cha_user_groups");

            migrationBuilder.DropTable(
                name: "tbl_cha_user_groups_details");

            migrationBuilder.DropTable(
                name: "tbl_cha_user_session");

            migrationBuilder.DropTable(
                name: "tbl_cha_visitor_chat_message");

            migrationBuilder.DropTable(
                name: "tbl_cha_visitor_chat_session");

            migrationBuilder.DropTable(
                name: "tbl_cha_visitor_queue");

            migrationBuilder.DropTable(
                name: "tbl_cha_visitor_session");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_mst_ci_type");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_mst_ci_type_attr");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_mst_software");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_mst_vendor");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_ticket_link");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_trn_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_trn_attachment");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_trn_ci");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_trn_ci_detail");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_trn_notes_log");

            migrationBuilder.DropTable(
                name: "tbl_cmdb_trn_software_ci_map");

            migrationBuilder.DropTable(
                name: "tbl_cnf_ad_ldap_field_map");

            migrationBuilder.DropTable(
                name: "tbl_cnf_ad_schedule");

            migrationBuilder.DropTable(
                name: "tbl_cnf_bus_rule_action");

            migrationBuilder.DropTable(
                name: "tbl_cnf_bus_rule_cond");

            migrationBuilder.DropTable(
                name: "tbl_cnf_catalog_cat");

            migrationBuilder.DropTable(
                name: "tbl_cnf_catalog_cost");

            migrationBuilder.DropTable(
                name: "tbl_cnf_catalog_question_dtls");

            migrationBuilder.DropTable(
                name: "tbl_cnf_config_item");

            migrationBuilder.DropTable(
                name: "tbl_cnf_config_item_mst");

            migrationBuilder.DropTable(
                name: "tbl_cnf_data_archive_cond");

            migrationBuilder.DropTable(
                name: "tbl_cnf_datadrive_visborad");

            migrationBuilder.DropTable(
                name: "tbl_cnf_email_mgr_extract_field");

            migrationBuilder.DropTable(
                name: "tbl_cnf_email_mgr_rule");

            migrationBuilder.DropTable(
                name: "tbl_cnf_follow_up");

            migrationBuilder.DropTable(
                name: "tbl_cnf_follow_up_type");

            migrationBuilder.DropTable(
                name: "tbl_cnf_helpdesk_list");

            migrationBuilder.DropTable(
                name: "tbl_cnf_mail_outgoing");

            migrationBuilder.DropTable(
                name: "tbl_cnf_notify_rule");

            migrationBuilder.DropTable(
                name: "tbl_cnf_notify_rule_org_map");

            migrationBuilder.DropTable(
                name: "tbl_cnf_priority_matrix");

            migrationBuilder.DropTable(
                name: "tbl_cnf_priority_user_map");

            migrationBuilder.DropTable(
                name: "tbl_cnf_sequence_override");

            migrationBuilder.DropTable(
                name: "tbl_cnf_sla_action");

            migrationBuilder.DropTable(
                name: "tbl_cnf_sla_cond");

            migrationBuilder.DropTable(
                name: "tbl_cnf_template_change");

            migrationBuilder.DropTable(
                name: "tbl_cnf_template_incident");

            migrationBuilder.DropTable(
                name: "tbl_cnf_template_problem");

            migrationBuilder.DropTable(
                name: "tbl_cnf_template_queue");

            migrationBuilder.DropTable(
                name: "tbl_cnf_template_queue_map");

            migrationBuilder.DropTable(
                name: "tbl_cnf_template_role_map");

            migrationBuilder.DropTable(
                name: "tbl_cnf_template_service_req");

            migrationBuilder.DropTable(
                name: "tbl_cnf_template_tkt_approval");

            migrationBuilder.DropTable(
                name: "tbl_cnf_template_tkt_task");

            migrationBuilder.DropTable(
                name: "tbl_cnf_ticket_sch");

            migrationBuilder.DropTable(
                name: "tbl_cnf_ticket_trending");

            migrationBuilder.DropTable(
                name: "tbl_cnf_tkt_num_format");

            migrationBuilder.DropTable(
                name: "tbl_dboard_dashboard");

            migrationBuilder.DropTable(
                name: "tbl_dboard_dashboard_filter");

            migrationBuilder.DropTable(
                name: "tbl_dboard_dashboard_panel");

            migrationBuilder.DropTable(
                name: "tbl_dboard_dashboard_panel_color");

            migrationBuilder.DropTable(
                name: "tbl_dboard_dashboard_panel_detail");

            migrationBuilder.DropTable(
                name: "tbl_dboard_dashboard_panel_drilldown");

            migrationBuilder.DropTable(
                name: "tbl_dboard_dashboard_panel_filter");

            migrationBuilder.DropTable(
                name: "tbl_dboard_mst_visual");

            migrationBuilder.DropTable(
                name: "tbl_dboard_mst_visual_detail");

            migrationBuilder.DropTable(
                name: "tbl_grid_state");

            migrationBuilder.DropTable(
                name: "tbl_grid_state1");

            migrationBuilder.DropTable(
                name: "tbl_mst_action_menu");

            migrationBuilder.DropTable(
                name: "tbl_mst_activity_type");

            migrationBuilder.DropTable(
                name: "tbl_mst_admin_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_mst_bulletin");

            migrationBuilder.DropTable(
                name: "tbl_mst_city");

            migrationBuilder.DropTable(
                name: "tbl_mst_country");

            migrationBuilder.DropTable(
                name: "tbl_mst_cti_ent_mod_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_db_view_column");

            migrationBuilder.DropTable(
                name: "tbl_mst_default_configuration");

            migrationBuilder.DropTable(
                name: "tbl_mst_department");

            migrationBuilder.DropTable(
                name: "tbl_mst_dept_category_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_entity_module_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_entityattr_org_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_flash");

            migrationBuilder.DropTable(
                name: "tbl_mst_holiday");

            migrationBuilder.DropTable(
                name: "tbl_mst_holiday_grp");

            migrationBuilder.DropTable(
                name: "tbl_mst_holiday_grp_site_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_holiday_queue_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_language ");

            migrationBuilder.DropTable(
                name: "tbl_mst_ldapad_attr");

            migrationBuilder.DropTable(
                name: "tbl_mst_ldapuser_attr");

            migrationBuilder.DropTable(
                name: "tbl_mst_menu");

            migrationBuilder.DropTable(
                name: "tbl_mst_module_cust_field_role_mapper");

            migrationBuilder.DropTable(
                name: "tbl_mst_org_module_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_org_queue_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_org_site_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_pwd_policy");

            migrationBuilder.DropTable(
                name: "tbl_mst_queue_module_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_role_access_right");

            migrationBuilder.DropTable(
                name: "tbl_mst_role_action_right");

            migrationBuilder.DropTable(
                name: "tbl_mst_sla_color");

            migrationBuilder.DropTable(
                name: "tbl_mst_state");

            migrationBuilder.DropTable(
                name: "tbl_mst_sub_module");

            migrationBuilder.DropTable(
                name: "tbl_mst_timezone");

            migrationBuilder.DropTable(
                name: "tbl_mst_user_dept_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_user_org_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_user_profile");

            migrationBuilder.DropTable(
                name: "tbl_mst_user_pwd");

            migrationBuilder.DropTable(
                name: "tbl_mst_user_queue_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_user_role_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_user_site_map");

            migrationBuilder.DropTable(
                name: "tbl_mst_wk_work_hr");

            migrationBuilder.DropTable(
                name: "tbl_mst_work_hr_queue_map");

            migrationBuilder.DropTable(
                name: "tbl_rpt_report");

            migrationBuilder.DropTable(
                name: "tbl_rpt_report_color");

            migrationBuilder.DropTable(
                name: "tbl_rpt_report_detail");

            migrationBuilder.DropTable(
                name: "tbl_rpt_report_drilldown");

            migrationBuilder.DropTable(
                name: "tbl_rpt_report_filter");

            migrationBuilder.DropTable(
                name: "tbl_rpt_report_scheduler");

            migrationBuilder.DropTable(
                name: "tbl_rpt_schedule_export");

            migrationBuilder.DropTable(
                name: "tbl_rpt_widget");

            migrationBuilder.DropTable(
                name: "tbl_rpt_widget_report_hide");

            migrationBuilder.DropTable(
                name: "tbl_rpt_widget_user_option");

            migrationBuilder.DropTable(
                name: "tbl_schedule_event");

            migrationBuilder.DropTable(
                name: "tbl_survey_mst_form_question_detail");

            migrationBuilder.DropTable(
                name: "tbl_trn_appr_attachment");

            migrationBuilder.DropTable(
                name: "tbl_trn_approval");

            migrationBuilder.DropTable(
                name: "tbl_trn_archive_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_catalog_order");

            migrationBuilder.DropTable(
                name: "tbl_trn_cr_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_cr_attachment");

            migrationBuilder.DropTable(
                name: "tbl_trn_cr_details");

            migrationBuilder.DropTable(
                name: "tbl_trn_cr_notes_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_field_service");

            migrationBuilder.DropTable(
                name: "tbl_trn_field_service_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_field_service_attachment");

            migrationBuilder.DropTable(
                name: "tbl_trn_field_service_notes_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_freefrm_visborad_assignto");

            migrationBuilder.DropTable(
                name: "tbl_trn_freefrm_visborad_attach");

            migrationBuilder.DropTable(
                name: "tbl_trn_freefrm_visborad_chklist");

            migrationBuilder.DropTable(
                name: "tbl_trn_freefrm_visborad_label");

            migrationBuilder.DropTable(
                name: "tbl_trn_freefrm_visborad_note");

            migrationBuilder.DropTable(
                name: "tbl_trn_impactedci");

            migrationBuilder.DropTable(
                name: "tbl_trn_inc_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_inc_attachment");

            migrationBuilder.DropTable(
                name: "tbl_trn_inc_notes_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_incident");

            migrationBuilder.DropTable(
                name: "tbl_trn_interaction");

            migrationBuilder.DropTable(
                name: "tbl_trn_interaction_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_interaction_attachment");

            migrationBuilder.DropTable(
                name: "tbl_trn_kb_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_kb_attachment");

            migrationBuilder.DropTable(
                name: "tbl_trn_kb_comment");

            migrationBuilder.DropTable(
                name: "tbl_trn_kb_notes_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_ldap_staging");

            migrationBuilder.DropTable(
                name: "tbl_trn_login_activity");

            migrationBuilder.DropTable(
                name: "tbl_trn_pr_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_pr_attachment");

            migrationBuilder.DropTable(
                name: "tbl_trn_pr_notes_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_problem_mpr");

            migrationBuilder.DropTable(
                name: "tbl_trn_sr_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_sr_attachment");

            migrationBuilder.DropTable(
                name: "tbl_trn_sr_notes_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_task");

            migrationBuilder.DropTable(
                name: "tbl_trn_task_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_task_attachment");

            migrationBuilder.DropTable(
                name: "tbl_trn_task_notes_log");

            migrationBuilder.DropTable(
                name: "tbl_trn_ticket_cust_field_detail");

            migrationBuilder.DropTable(
                name: "tbl_trn_ticket_link");

            migrationBuilder.DropTable(
                name: "tbl_trn_ticket_sla");

            migrationBuilder.DropTable(
                name: "tbl_trn_ticket_spent_time");

            migrationBuilder.DropTable(
                name: "tbl_trn_ticket_survey_question");

            migrationBuilder.DropTable(
                name: "tbl_trn_user_location");

            migrationBuilder.DropTable(
                name: "tbl_trn_user_notification");

            migrationBuilder.DropTable(
                name: "tbl_trn_watch_list");

            migrationBuilder.DropTable(
                name: "usermaster");

            migrationBuilder.DropTable(
                name: "view_myfav_myapprovals");

            migrationBuilder.DropTable(
                name: "www_view_dboard_incident_problem_linked_records");

            migrationBuilder.DropTable(
                name: "www_view_dboard_problem_incident_link");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mst_discovery");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_mst_discovery_rule");

            migrationBuilder.DropTable(
                name: "tbl_autodisc_trn_discovery");

            migrationBuilder.DropTable(
                name: "tbl_cnf_ad_ldap");

            migrationBuilder.DropTable(
                name: "tbl_cnf_bus_rule");

            migrationBuilder.DropTable(
                name: "tbl_cnf_data_archive");

            migrationBuilder.DropTable(
                name: "tbl_cnf_email_mgr");

            migrationBuilder.DropTable(
                name: "tbl_cnf_email_template");

            migrationBuilder.DropTable(
                name: "tbl_cnf_bus_field");

            migrationBuilder.DropTable(
                name: "tbl_cnf_sla");

            migrationBuilder.DropTable(
                name: "tbl_mst_admin_module");

            migrationBuilder.DropTable(
                name: "tbl_mst_db_view");

            migrationBuilder.DropTable(
                name: "tbl_mst_role");

            migrationBuilder.DropTable(
                name: "tbl_mst_work_hr");

            migrationBuilder.DropTable(
                name: "tbl_survey_mst_form_question");

            migrationBuilder.DropTable(
                name: "tbl_cnf_catalog_resource_dtls");

            migrationBuilder.DropTable(
                name: "tbl_trn_service_request");

            migrationBuilder.DropTable(
                name: "tbl_trn_change");

            migrationBuilder.DropTable(
                name: "tbl_trn_freefrm_visborad_card");

            migrationBuilder.DropTable(
                name: "tbl_trn_kb");

            migrationBuilder.DropTable(
                name: "tbl_trn_problem");

            migrationBuilder.DropTable(
                name: "tbl_mst_module_cust_field");

            migrationBuilder.DropTable(
                name: "tbl_trn_ticket_survey");

            migrationBuilder.DropTable(
                name: "tbl_mst_module");

            migrationBuilder.DropTable(
                name: "tbl_survey_mst_form");

            migrationBuilder.DropTable(
                name: "tbl_cnf_catalog_resource");

            migrationBuilder.DropTable(
                name: "tbl_cnf_freefrm_visborad_lane");

            migrationBuilder.DropTable(
                name: "tbl_mst_queue");

            migrationBuilder.DropTable(
                name: "tbl_mst_entity_attr");

            migrationBuilder.DropTable(
                name: "tbl_mst_attachment");

            migrationBuilder.DropTable(
                name: "tbl_cnf_catalog_question");

            migrationBuilder.DropTable(
                name: "tbl_cnf_freefrm_visborad");

            migrationBuilder.DropTable(
                name: "tbl_mst_entity");

            migrationBuilder.DropTable(
                name: "tbl_mst_org");

            migrationBuilder.DropTable(
                name: "tbl_mst_user");

            migrationBuilder.DropTable(
                name: "tbl_mst_site");

            migrationBuilder.DropSequence(
                name: "bot_master_menu_seq");

            migrationBuilder.DropSequence(
                name: "bot_master_profile_seq");

            migrationBuilder.DropSequence(
                name: "bot_message_details_seq");

            migrationBuilder.DropSequence(
                name: "bot_message_seq");

            migrationBuilder.DropSequence(
                name: "bot_profile_detail_seq");

            migrationBuilder.DropSequence(
                name: "bot_system_configuration_seq");

            migrationBuilder.DropSequence(
                name: "bot_system_reports_setting_seq");

            migrationBuilder.DropSequence(
                name: "bot_user_details_seq");

            migrationBuilder.DropSequence(
                name: "bot_user_login_seq");

            migrationBuilder.DropSequence(
                name: "hibernate_sequence");

            migrationBuilder.DropSequence(
                name: "tbl_autodisc_mac_info_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_autodisc_mst_discovery_ip_address_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_autodisc_mst_discovery_rule_action_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_autodisc_mst_discovery_rule_condition_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_autodisc_mst_discovery_rule_discovery_rule_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_autodisc_mst_mib_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_autodisc_trn_discovery_detail_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_autodisc_trn_discovery_discovery_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cha_user_session_user_session_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cmdb_disc_mst_credential_credential_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cmdb_disc_mst_credential_type_credential_type_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cmdb_disc_mst_discovery_discovery_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cmdb_disc_mst_discovery_schedule_schedule_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cmdb_mst_software_software_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cmdb_trn_software_ci_map_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_config_item_mst_config_item_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_data_archive_archive_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_data_archive_cond_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_email_mgr_extract_field_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_priority_user_map_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_survey_cond_survey_cond_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_survey_ques_survey_ques_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_survey_survey_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_template_queue_template_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_template_tkt_approval_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_cnf_template_tkt_task_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_grid_state_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_action_menu_action_menu_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_activity_type_activity_type_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_cti_ent_mod_map_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_default_configuration_config_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_dept_entityattr_map_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_entityattr_org_map_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_flash_flash_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_ldapad_attr_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_ldapuser_attr_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_module_cust_field_role_mapper_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_module_cust_field_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_old_pwd_pid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_org_category_map_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_pwd_policy_pid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_role_action_right_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_survey_close_cond_survey_close_cond_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_survey_type_survey_type_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_ticket_id_format_ticket_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_wmi_ID_seq");

            migrationBuilder.DropSequence(
                name: "tbl_mst_work_hr_queue_map_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_rpt_widget_user_option_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_survey_mst_form_question_detail_detail_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_survey_mst_form_question_question_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_survey_mst_form_survey_form_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_survey_trn_ticket_question_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_survey_trn_ticket_survey_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_activity_log_activity_log_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_archive_log_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_field_service_activity_log_activity_log_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_field_service_attachment_attachment_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_field_service_field_service_id1_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_field_service_notes_log_notes_log_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_interaction_activity_log_activity_log_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_interaction_attachment_attachment_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_interaction_interaction_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_ldap_staging_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_problem_mpr_mpr_id_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_ticket_cust_field_detail_uid_seq");

            migrationBuilder.DropSequence(
                name: "tbl_trn_watch_list_watch_list_id_seq");

            migrationBuilder.DropSequence(
                name: "user_chat_message_seq");

            migrationBuilder.DropSequence(
                name: "user_chat_message_user_chat_message_id_seq");

            migrationBuilder.DropSequence(
                name: "user_chat_session_seq");

            migrationBuilder.DropSequence(
                name: "user_chat_session_user_chat_session_id_seq");

            migrationBuilder.DropSequence(
                name: "user_details_seq");

            migrationBuilder.DropSequence(
                name: "user_details_user_id_seq");

            migrationBuilder.DropSequence(
                name: "user_group_message_group_message_id_seq");

            migrationBuilder.DropSequence(
                name: "user_group_message_seq");

            migrationBuilder.DropSequence(
                name: "user_groups_details_seq");

            migrationBuilder.DropSequence(
                name: "user_groups_details_user_group_details_id_seq");

            migrationBuilder.DropSequence(
                name: "user_groups_group_id_seq");

            migrationBuilder.DropSequence(
                name: "user_groups_seq");

            migrationBuilder.DropSequence(
                name: "user_online_seq");

            migrationBuilder.DropSequence(
                name: "user_session_seq");

            migrationBuilder.DropSequence(
                name: "user_session_user_session_id_seq");

            migrationBuilder.DropSequence(
                name: "visitor_chat_message_seq");

            migrationBuilder.DropSequence(
                name: "visitor_chat_message_visitor_chat_message_id_seq");

            migrationBuilder.DropSequence(
                name: "visitor_chat_session_seq");

            migrationBuilder.DropSequence(
                name: "visitor_chat_session_visitor_chat_session_id_seq");

            migrationBuilder.DropSequence(
                name: "visitor_details_seq");

            migrationBuilder.DropSequence(
                name: "visitor_queue_seq");

            migrationBuilder.DropSequence(
                name: "visitor_queue_visitor_queue_id_seq");

            migrationBuilder.DropSequence(
                name: "visitor_session_seq");

            migrationBuilder.DropSequence(
                name: "visitor_session_visitor_session_id_seq");
        }
    }
}
