#include <stdio.h>
#include <stdlib.h>
#include <time.h>
//#include <string.h>

typedef struct  s_total
{
    float totalcredit;
    float totalpercent;
    float totalsum;
}               t_total;

typedef struct  s_data
{
    float sum;
    float percent;
    int month;
    int i;
    t_total total;
}               t_data;



float   maindept(t_data *data)
{
    return (data->sum / data->month);
}

float   outstanding(t_data *data)
{
    return (data->sum + maindept(data) - data->sum / data->month * data->i);
}

float   percentsum(t_data *data)
{
    float standing;
    float persum;

    standing = outstanding(data);
    // Считает не точно, а примерно, т.к. всегда 31 день
    persum = standing * (data->percent / 100 * 31 / 365);
    return (persum);
}

float   totalpayment(t_data *data)
{
    float dept;
    float percent;

    dept = maindept(data);
    percent = percentsum(data);
    return (dept + percent);
}

void    outputstring(t_data *data)
{
    data->i = 1;
    
    printf("%d)\t%8.2f\t-\t\t-\t\t-\n", 0, -data->sum);
    while (data->i <= data->month)
    {
        float percent = percentsum(data);
        float totalpay = totalpayment(data);
        float main = maindept(data);
        float outstand = outstanding(data);
        printf("%i)\t%8.2f\t%8.2f\t%8.2f\t%8.2f\n", data->i, 
        totalpay, percent, main, outstand);
        data->i++;
        data->total.totalcredit += totalpay;
        data->total.totalpercent += percent;
        data->total.totalsum += main;
    }
    //data->total.totalsum;
    printf("%s\t%8.2f\t%8.2f\t%8.2f\t%8d\n", "Result", data->total.totalcredit,
    data->total.totalpercent, data->total.totalsum, 0);
}

int main(int argc, char **argv)
{
    if (argc == 4)
    {
        t_data data;

        data.sum = atof(argv[1]);
        printf("%f\n", data.sum);
        data.percent = atof(argv[2]);
        data.month = atoi(argv[3]);
        outputstring(&data);
        return(0);
    }
    else
        printf("error\n");
}