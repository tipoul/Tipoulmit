"use strict";

// Class Definition
var KTLogin = function () {
    var _login;

    var _showForm = function (form) {
        var cls = 'login-' + form + '-on';
        var form = 'kt_login_' + form + '_form';

        _login.removeClass('login-forgot-on');
        _login.removeClass('login-signin-on');
        _login.removeClass('login-signup-on');

        _login.addClass(cls);

        KTUtil.animateClass(KTUtil.getById(form), 'animate__animated animate__backInUp');
    }

    var _handleSignInForm = function () {
        var validation;

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            KTUtil.getById('kt_login_signin_form'),
            {
                fields: {
                    UserName: {
                        validators: {
                            notEmpty: {
                                message: 'وارد کردن نام کاربری اجباری است'
                            }
                        }
                    },
                    Password: {
                        validators: {
                            notEmpty: {
                                message: 'وارد کردن کلمه عبور اجباری است'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    //defaultSubmit: new FormValidation.plugins.DefaultSubmit(), // Uncomment this line to enable normal button submit after form validation
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        $('#kt_login_signin_form').on('submit', function () {
            var btn = $("#kt_login_signin_submit");
            btn.prop("disabled", true);
            var oldHtml = btn.html();
            btn.html("در حال بارگزاری");
            $("#invelidVerificationCode").hide();

            $.ajax({
                url: "/login",
                method: "POST",
                data: $(this).serialize(),
                success: function (response) {
                    btn.html(oldHtml).prop("disabled", false);
                    //if (response.token) {
                    //    btn.html("در حال انتقال");
                    //    $("#token").val(response.token);
                    //    $("#resultForm").submit();
                    //}
                    btn.prop("disabled", false);
                    btn.html(oldHtml);
                    if (response.notExists)
                        swal.fire({
                            text: "نام کاربری و یا شماره موبایل صحیح نیست.",
                            icon: "error",
                            buttonsStyling: false,
                            confirmButtonText: "تأیید و اصلاح",
                            customClass: {
                                confirmButton: "btn font-weight-bold btn-light-primary"
                            }
                        });
                    else if (response.banded)
                        swal.fire({
                            text: "حساب کاربری شما معلق شده است",
                            icon: "error",
                            buttonsStyling: false,
                            confirmButtonText: "تأیید و اصلاح",
                            customClass: {
                                confirmButton: "btn font-weight-bold btn-light-primary"
                            }
                        });
                    else if (response.passwordNeeded) {
                        $("#UserName").parent().fadeOut();
                        $("#SecondInput").prop("required", true).prop("name", "password").prop("placeholder", "کلمه عبور").parent().fadeIn();
                    }
                    else if (response.verificationCodeSent) {
                        $("#UserName").parent().fadeOut();
                        $("#SecondInput").prop("required", true).prop("name", "verificationCode").prop("placeholder", "کد احراز هویت").focus().parent().fadeIn();
                        //$("#SecondInput").val("1");
                        //$("#kt_login_signin_form").submit();
                    }
                    else if (response.inVerificationCode)
                        $("#invelidVerificationCode").show();
                    else if (response.token) {
                        btn.html("در حال انتقال");
                        $("#token").val(response.token);
                        $("#resultForm").submit();
                    }
                }
            });
            return false;
        });
        //$("#UserName").val("1");
        //$("#kt_login_signin_form").submit();

        $('#kt_login_signin_submit').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    btn.parents("form").submit();
                } else {
                    swal.fire({
                        text: "با عرض پوزش ، به نظر می رسد برخی از خطاها شناسایی شده اند ، لطفا دوباره امتحان کنید.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "تأیید و اصلاح",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });

        // Handle forgot button
        $('#kt_login_forgot').on('click', function (e) {
            e.preventDefault();
            _showForm('forgot');
        });

        // Handle signup
        $('#kt_login_signup').on('click', function (e) {
            e.preventDefault();
            _showForm('signup');
        });
    }

    var _handleSignUpForm = function (e) {
        var validation;
        var form = KTUtil.getById('kt_login_signup_form');

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            form,
            {
                fields: {
                    fullname: {
                        validators: {
                            notEmpty: {
                                message: 'وارد کردن نام کاربری اجباری است'
                            }
                        }
                    },
                    email: {
                        validators: {
                            notEmpty: {
                                message: 'آدرس ایمیل لازم است'
                            },
                            emailAddress: {
                                message: "مقدار یک آدرس ایمیل معتبر نیست"
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: 'The password is required'
                            }
                        }
                    },
                    cpassword: {
                        validators: {
                            notEmpty: {
                                message: "تأیید رمز عبور لازم است"
                            },
                            identical: {
                                compare: function () {
                                    return form.querySelector('[name="password"]').value;
                                },
                                message: "رمز عبور و تأیید آن یکسان نیستند"
                            }
                        }
                    },
                    agree: {
                        validators: {
                            notEmpty: {
                                message: 'شما باید قوانین و ضوابط را بپذیرید'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        $('#kt_login_signup_submit').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    swal.fire({
                        text: "همه چیز جالب است! اکنون این فرم را ارسال می کنید",
                        icon: "success",
                        buttonsStyling: false,
                        confirmButtonText: "باشه فهمیدم!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                } else {
                    swal.fire({
                        text: "با عرض پوزش ، به نظر می رسد برخی از خطاها شناسایی شده اند ، لطفا دوباره امتحان کنید.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "باشه فهمیدم!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });

        // Handle cancel button
        $('#kt_login_signup_cancel').on('click', function (e) {
            e.preventDefault();

            _showForm('signin');
        });
    }

    var _handleForgotForm = function (e) {
        var validation;

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            KTUtil.getById('kt_login_forgot_form'),
            {
                fields: {
                    email: {
                        validators: {
                            notEmpty: {
                                message: 'آدرس ایمیل لازم است'
                            },
                            emailAddress: {
                                message: "مقدار یک آدرس ایمیل معتبر نیست"
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        // Handle submit button
        $('#kt_login_forgot_submit').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    // Submit form
                    KTUtil.scrollTop();
                } else {
                    swal.fire({
                        text: "با عرض پوزش ، به نظر می رسد برخی از خطاها شناسایی شده اند ، لطفا دوباره امتحان کنید.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "باشه فهمیدم!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });

        // Handle cancel button
        $('#kt_login_forgot_cancel').on('click', function (e) {
            e.preventDefault();

            _showForm('signin');
        });
    }

    // Public Functions
    return {
        // public functions
        init: function () {
            _login = $('#kt_login');

            _handleSignInForm();
            _handleSignUpForm();
            _handleForgotForm();
        }
    };
}();

// Class Initialization
jQuery(document).ready(function () {
    KTLogin.init();
});
