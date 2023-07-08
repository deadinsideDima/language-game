using System;
using System.Globalization;

namespace LanguageGame
{
    public static class Translator
    {
        /// <summary>
        /// Translates from English to Pig Latin. Pig Latin obeys a few simple following rules:
        /// - if word starts with vowel sounds, the vowel is left alone, and most commonly 'yay' is added to the end;
        /// - if word starts with consonant sounds or consonant clusters, all letters before the initial vowel are
        ///   placed at the end of the word sequence. Then, "ay" is added.
        /// Note: If a word begins with a capital letter, then its translation also begins with a capital letter,
        /// if it starts with a lowercase letter, then its translation will also begin with a lowercase letter.
        /// </summary>
        /// <param name="phrase">Source phrase.</param>
        /// <returns>Phrase in Pig Latin.</returns>
        /// <exception cref="ArgumentException">Thrown if phrase is null or empty.</exception>
        /// <example>
        /// "apple" -> "appleyay"
        /// "Eat" -> "Eatyay"
        /// "explain" -> "explainyay"
        /// "Smile" -> "Ilesmay"
        /// "Glove" -> "Oveglay".
        /// </example>
        public static string TranslateToPigLatin(string phrase)
        {
            if (string.IsNullOrEmpty(phrase) || string.IsNullOrWhiteSpace(phrase))
            {
                throw new ArgumentException("Phrase is null or empty or white space.");
            }

            string array = string.Empty;
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase.Length - i > 3 && phrase[i] == 'b' && phrase[i + 1] == 'y' && phrase[i + 2] == ' ')
                {
                    array = string.Empty + array + "byay";
                    i += 2;
                }

                if (phrase[i] == 'a' || phrase[i] == 'o' || phrase[i] == 'e' || phrase[i] == 'i' || phrase[i] == 'u' || phrase[i] == 'A' || phrase[i] == 'O' || phrase[i] == 'E' || phrase[i] == 'I' || phrase[i] == 'U')
                {
                    int temp = 0;
                    while (i + temp < phrase.Length)
                    {
                        if (phrase[i + temp] == ' ' || phrase[i + temp] == '.' || phrase[i + temp] == ',' || phrase[i + temp] == '!' || phrase[i + temp] == '-')
                        {
                            break;
                        }

                        temp++;
                    }

                    for (int j = i; j < i + temp; j++)
                    {
                        array = string.Empty + array + phrase[j];
                    }

                    array = string.Empty + array + "yay";
                    i += temp;
                }
                else if (phrase[i] != 'a' && phrase[i] != 'o' && phrase[i] != 'e' && phrase[i] != 'i' && phrase[i] != 'u' && phrase[i] != 'A' && phrase[i] != 'O' && phrase[i] != 'E' && phrase[i] != 'I' && phrase[i] != 'U' && phrase[i] != ' ' && phrase[i] != '.' && phrase[i] != ',' && phrase[i] != '!' && phrase[i] != '-')
                {
                    bool b = char.IsUpper(phrase[i]);
                    if (b)
                    {
                        string arrtemp = string.Empty;
                        int temp = 0;
                        while ((phrase[i + temp] != 'a' && phrase[i + temp] != 'o' && phrase[i + temp] != 'e' && phrase[i + temp] != 'i' && phrase[i + temp] != 'u') && temp + i < phrase.Length)
                        {
                            arrtemp = string.Empty + arrtemp + char.ToLower(phrase[i + temp], CultureInfo.CurrentCulture);
                            temp++;
                        }

                        array = string.Empty + array + char.ToUpper(phrase[i + temp], CultureInfo.CurrentCulture);
                        temp++;
                        int temp1 = 0;
                        while (i + temp + temp1 < phrase.Length)
                        {
                            if (phrase[i + temp + temp1] == ' ' || phrase[i + temp + temp1] == '.' || phrase[i + temp + temp1] == ',' || phrase[i + temp + temp1] == '!')
                            {
                                break;
                            }

                            temp1++;
                        }

                        for (int j = i + temp; j < i + temp + temp1; j++)
                        {
                            array = string.Empty + array + phrase[j];
                        }

                        array = string.Empty + array + arrtemp + "ay";
                        i += temp + temp1;
                    }
                    else
                    {
                        string arrayTemp = string.Empty;
                        int temp = 0;
                        while ((phrase[i + temp] != 'a' && phrase[i + temp] != 'o' && phrase[i + temp] != 'e' && phrase[i + temp] != 'i' && phrase[i + temp] != 'u') && temp + i < phrase.Length)
                        {
                            arrayTemp = string.Empty + arrayTemp + phrase[i + temp];
                            temp++;
                        }

                        array = string.Empty + array + phrase[i + temp];
                        temp++;
                        int temp1 = 0;
                        while (i + temp + temp1 < phrase.Length)
                        {
                            if (phrase[i + temp + temp1] == ' ' || phrase[i + temp + temp1] == '.' || phrase[i + temp + temp1] == ',' || phrase[i + temp + temp1] == '!')
                            {
                                break;
                            }

                            temp1++;
                        }

                        for (int j = i + temp; j < i + temp + temp1; j++)
                        {
                            array = string.Empty + array + phrase[j];
                        }

                        array = string.Empty + array + arrayTemp + "ay";
                        i += temp + temp1;
                    }
                }

                if (i < phrase.Length)
                {
                    array = string.Empty + array + phrase[i];
                }
            }

            return array;
        }
    }
}
