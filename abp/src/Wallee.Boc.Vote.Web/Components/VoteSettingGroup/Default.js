(function ($) {
    $(function () {
        var l = abp.localization.getResource('Vote');
        $("#ViteSettingsForm").on('submit', function (event) {
            event.preventDefault();
            if (!$(this).valid()) {
                return;
            }
            var form = $(this).serializeFormToObject();
            wallee.boc.vote.settings.voteSettings.updateVoteSettings(form).then(function (result) {
                $(document).trigger("AbpSettingSaved");
            });

        });
    });

})(jQuery);