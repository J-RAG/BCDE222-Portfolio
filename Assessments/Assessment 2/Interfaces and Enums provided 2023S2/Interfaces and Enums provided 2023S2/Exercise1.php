<?php
    class Conditonals
    {
        public string $result;

        const MIN_GRADE_PASS = 50;

        // Exercise 1
        public function check_mark(double $grade)
        {
            $result = "FAIL"; // Initial Value set
            if ($grade >= Conditionals::MIN_GRADE_PASS)
            {
                $$result = "PASS";
            }
            return $result;
        }

        // Exercise 2
        public function is_odd_number(int $number)
        {
            $result = "Even $number";
            if ($number % 2 != 0)
            {
                $result = "Odd $number";
            }
            return $result;
        }

        // Exercise 3
        public function number_name(int $number)
        {
            return $number switch
            {
                0 => "ZERO",
                1 => "ONE",
                2 => "TWO",
                3 => "THREE",
                4 => "FOUR",
                5 => "FIVE",
                6 => "SIX",
                7 => "SEVEN",
                8 => "EIGHT",
                9 => "NINE",
                _ => "OTHER",
            };
        }
    }

    $con = new Conditonals();

    echo "Exercise 1:";
    echo "Your grade is 50 you are given a {$con.check_mark(50)}";
    echo "Your grade is 49 you are given a {$con.check_mark(49)}";
    echo "";

    echo "Question 2:";
    echo "The number 23454231 is a {$con.is_odd_number(2345321)}";
    echo "The number 0 is an {$con.is_odd_number(0)}";
    echo "";

    echo "Question 3:";
    for (int $i = 0; $i < 10; $i++) 
    {
        echo "{$i} is {$con.number_name($i)} in word form";
    }

    echo "10 is outside the range for this program. It will be classified as: \"{$con.number_name(10)}\".";
    echo "100 is outside the range for this program. It will be classified as: \"{$con.number_name(100)}\".";
    



