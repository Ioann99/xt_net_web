class ListSwaper
{
    constructor(containers, buttons)
    {
        this.data = {
            containers: containers,
            buttons: buttons,
            error_func: this.at_error,
        }
    }

    link_event_functions()
    {
        //alert('link');
        this.data.buttons.all_to_left_button.addEventListener('click', this.event_all_to_left(this.data));
        this.data.buttons.all_to_right_button.addEventListener('click', this.event_all_to_right(this.data));
        this.data.buttons.to_left_button.addEventListener('click', this.event_to_left(this.data));
        this.data.buttons.to_right_button.addEventListener('click', this.event_to_right(this.data));
    }

    unlink_event_functions()
    {
        //alert('unlink');
        this.data.buttons.all_to_left_button.removeEventListener('click', this.event_all_to_left(this.data));
        this.data.buttons.all_to_right_button.removeEventListener('click', this.event_all_to_right(this.data));
        this.data.buttons.to_left_button.removeEventListener('click', this.event_to_left(this.data));
        this.data.buttons.to_right_button.removeEventListener('click', this.event_to_right(this.data));
    }

    event_all_to_left(data)
    {
        return () => {
            var con_r = data.containers.container_right;
            var con_l = data.containers.container_left;

            for (var i = con_r.options.length - 1; i >= 0; i--)
            {
                con_l.options[con_l.options.length] = con_r.options[0];
            }
        }
    }

    event_all_to_right(data)
    {
        return () => {
            var con_r = data.containers.container_right;
            var con_l = data.containers.container_left;

            for (var i = con_l.options.length - 1; i >= 0; i--)
            {
                con_r.options[con_r.options.length] = con_l.options[0];
            }
        }
    }

    event_to_left(data)
    {
        return () => {
            var con_r = data.containers.container_right;
            var con_l = data.containers.container_left;
            var index = con_r.selectedIndex;

            if (index == -1)
            {
                data.error_func();
            }
            else
            {
                con_l.options[con_l.options.length] = con_r.options[index];
            }
        }
    }

    event_to_right(data)
    {
        return () => {
            var con_r = data.containers.container_right;
            var con_l = data.containers.container_left;
            var index = con_l.selectedIndex;

            if (index == -1)
            {
                data.error_func();
            }
            else
            {
                con_r.options[con_r.options.length] = con_l.options[index];
            }
        }
    }

    at_error()
    {
        alert('You have not choose element')
    }
}

function init_test_list_class()
{
    var containers = {
        container_left: document.getElementById('container_1'),
        container_right: document.getElementById('container_2'),
    };

    var buttons = {
        all_to_left_button: document.getElementById('btn_all_to_left'),
        all_to_right_button: document.getElementById('btn_all_to_right'),
        to_left_button: document.getElementById('btn_to_left'),
        to_right_button: document.getElementById('btn_to_right'),
    };
    //alert('init');
    var res = new ListSwaper(containers, buttons);
    return res;
}

var test_linked_lists = init_test_list_class();
test_linked_lists.link_event_functions();
