function find_numbers(str)
{
    var reg_ex = /\d+(\.\d+)?/g;
    return str.match(reg_ex);
}

function find_operators(str)
{
    var reg_ex = /[+\-\/*]/g;
    return str.match(reg_ex);
}

function first_number(str, numbers)
{
    var res = parseFloat(numbers[0]);
    for (var i = 0; i < str.length; i++)
    {
        var t = str[i];
        if (t == '-')
        {
            return -res;
        }
        if (t != ' ' && t - 0 != NaN)
        {
            return res;
        }
    }
}

function use_operator(op1, op2, act)
{
    var a = parseFloat(op1);
    var b = parseFloat(op2);
    switch (act)
    {
        case '+': return a + b;
        case '-': return a - b;
        case '/': return a / b;
        case '*': return a * b;
    }
}

function handle_input_string()
{
    var input_str = document.getElementById('instr2').value;
    // input /\

    var numbers = find_numbers(input_str);
    var operators = find_operators(input_str);
    var res = first_number(input_str, numbers);

    var number_index = 1;
    var oper_index = (res < 0) ? 1 : 0;

    while (number_index < numbers.length)
    {
        res = use_operator(res, numbers[number_index], operators[oper_index]);
        number_index++;
        oper_index++;
    }

    // output \/
    document.getElementById('result2').innerHTML = res;
}
document.getElementById('handlebtn2').addEventListener('click', handle_input_string);
