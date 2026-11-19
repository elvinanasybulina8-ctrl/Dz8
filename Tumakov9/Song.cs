using System;

namespace Tumakov9
{
    public class Song
    {
        public string _name;
        public string _author;
        public Song? _connection; // связь с предыдущей песней (объектом Song)

        // Конструктор без параметров
        public Song()
        {
            this._name = "Название песни";
            this._author = "Исполнитель";
            this._connection = null;
        }

        // Конструктор с параметрами (название и автор)
        public Song(string name, string author)
        {
            this._name = name;
            this._author = author;
            this._connection = null;
        }

        // Конструктор с тремя параметрами (название, автор и предыдущая песня)
        public Song(string name, string author, Song? connection)
        {
            this._name = name;
            this._author = author;
            this._connection = connection;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public void SetAuthor(string author)
        {
            this._author = author;
        }

        public void SetConnection(Song? connection)
        {
            this._connection = connection;
        }

        public string Title()
        {
            return $"{this._name}, исполнитель: {this._author}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Song otherSong)
            {
                return false;
            }

            return this._name.Equals(otherSong._name) && this._author.Equals(otherSong._author);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _author);
        }
    }
}
