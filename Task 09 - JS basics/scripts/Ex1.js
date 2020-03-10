function find_repeat_letters(inp_str)
{
    var letters = [];
    var repeats = [];
    for (var i = 0; i < inp_str.length; i++)
    {
        var t = inp_str[i];

        if (letters.includes(t))
        {
            if (!repeats.includes(t))
            {
                repeats[repeats.length] = t;
            }
        }
        else
        {
            letters[letters.length] = t;
        }
    }

    return repeats;
}

function delete_repeat_letters(inp_str, repeats)
{
    var res = '';

    for (var i = 0; i < inp_str.length; i++)
    {
        var t = inp_str[i];

        if (!repeats.includes(t))
        {
            res += t;
        }
    }

    return res;
}

function handle_input_string()
{
    var input_str = document.getElementById('instr').value;
    // input /\

    var repeats = [];
    var words = input_str.split(' ');
    for (var word_index = 0; word_index < words.length; word_index++)
    {
        var t = find_repeat_letters(words[word_index]);
        t = t.filter((x) => !repeats.includes(x));
        repeats = repeats.concat(t);
    }

    var result_str = delete_repeat_letters(input_str, repeats);

    // output \/
    document.getElementById('result').innerHTML = result_str;
}
document.getElementById('handlebtn').addEventListener('click', handle_input_string);
