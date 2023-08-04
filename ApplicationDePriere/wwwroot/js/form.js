$(document).ready(function () {
    $(".form-wrapper .button").click(function () {
        var button = $(this);


        const currentSection = button.parents(".section");
        const prenom_expe = document.getElementById('prenom_expe').value;
        const nom_expe = document.getElementById('nom_expe').value;
        const email_expe = document.getElementById('email_expe').value;
        const prenom_dest = document.getElementById('prenom_dest').value;
        const email_dest = document.getElementById('email_dest').value;
        const sPriere = document.getElementById('sPriere').value;
        const priere = document.getElementById('priere').value;


        var currentSectionIndex = currentSection.index();

        var headerSection = $('.steps li').eq(currentSectionIndex);
        currentSection.removeClass("is-active").next().addClass("is-active");
        headerSection.removeClass("is-active").next().addClass("is-active");

        $(".form-wrapper").submit(function (e) {
            e.preventDefault();
            
            });

            if (currentSectionIndex === 3) {
                $(document).find(".form-wrapper .section").first().addClass("is-active");
                $(document).find(".steps li").first().addClass("is-active");
            }
        });
    });
