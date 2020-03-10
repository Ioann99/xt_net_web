var timer_configs = {
    //second_per_page: 3,
    //steps_in_second: 10,
    steps_in_page: 3 * 10,
    step_counter: 0,
    step_time: 100, // 1000 / steps_in_second,
}
var timer = 0;
var timer_disp = document.getElementById('timer_display');

var pages = ['../html/pages/ip1.html',
    '../html/pages/ip2.html',
    '../html/pages/ip3.html',
    '../html/pages/ip4.html',];
var page_index = 0;
var inner_page_element = document.getElementById('page_container');
var dialog_element = document.getElementById('finaly_dialog');

var prev_button = document.getElementById('btn_prev');
var stop_button = document.getElementById('btn_stop');
var play_button = document.getElementById('btn_play');

function print_timer_value()
{
    timer_disp.innerHTML = (
        ((timer_configs.steps_in_page - timer_configs.step_counter)
            * timer_configs.step_time) / 1000);
}

function clear_timer_value()
{
    timer_disp.innerHTML = '';
}

function timer_func()
{
    print_timer_value();
    timer_configs.step_counter++;

    if (timer_configs.step_counter >= timer_configs.steps_in_page)
    {
        page_time_is_over();
    }
}

function page_time_is_over()
{
    page_index++;
    if (page_index < pages.length)
    {
        timer_configs.step_counter = 0;
        set_page();
    }
    else
    {
        stop_timer();
        clear_timer_value();
        dialog_element.className = 'dialog_container_visible';
        disable_form();
    }
}

function disable_form()
{
    prev_button.disabled = "disabled";
    stop_button.disabled = "disabled";
    play_button.disabled = "disabled";
    inner_page_element.disabled = "disabled";
}

function ensable_form()
{
    prev_button.disabled = "";
    stop_button.disabled = "";
    play_button.disabled = "";
    inner_page_element.disabled = "";
}

function set_page()
{
    inner_page_element.src = pages[page_index];
}

function stop_timer()
{
    clearInterval(timer);
}

function star_timer()
{
    timer = setInterval(timer_func, timer_configs.step_time);
}

function prev_page()
{
    timer_configs.step_counter = 0;
    print_timer_value();
    if (page_index != 0) page_index--;
    set_page();
}

prev_button.addEventListener('click', prev_page);
stop_button.addEventListener('click', stop_timer);
play_button.addEventListener('click', star_timer);

function repeat_pages()
{
    timer_configs.step_counter = 0;
    page_index = 0;
    dialog_element.className = 'dialog_container_hidden';
    ensable_form();
    set_page();
    star_timer();
}

function close_gallery()
{
    inner_page_element.src = '';
    document.body.innerHTML = '';
    alert('Goodbye');
    window.close();
}

document.getElementById('btn_repeat').addEventListener('click', repeat_pages);
document.getElementById('btn_close').addEventListener('click', close_gallery);

set_page();
star_timer();
