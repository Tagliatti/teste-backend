FROM ruby:2.5.1

RUN apt-get update -qq && apt-get install -y build-essential libpq-dev

# Node JS
RUN curl -sL https://deb.nodesource.com/setup_8.x | bash -
RUN apt-get install -y nodejs

# Yarn
RUN npm i -g yarn

# Ruby on Rails template
RUN gem install rails -v 5.2.1 --no-document
RUN gem install bundle --no-document

# Bundle the gems required for a new application
RUN rails new /tmp/temp_app --database postgresql --quiet && rm -r /tmp/temp_app
RUN gem install therubyracer --no-document

WORKDIR /app

EXPOSE 3000

#ENTRYPOINT ["bundle", "exec"]

CMD ["bundle", "exec", "rails", "server", "-b", "0.0.0.0", "-p", "3000"]